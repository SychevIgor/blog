Положа руку на сердце, все ли из нас являются экспертами по вопросам безопасности? Лично я таковым не являюсь, и очень хотел бы, чтобы какой-то искусственный интеллект подумал про безопасность и сказал мне, где у меня потенциальные дырки… а дальше я уже разберусь.

<img align="center" height="450" src="https://habrastorage.org/files/58d/18d/86d/58d18d86da9c44b5a509c41c58e8658b.png"/>
В Azure в preview появилась достаточно полезная фича: <a href="https://azure.microsoft.com/en-us/services/security-center/">Azure Security Center</a>, которая умеет анализировать вашу инсталляцию (виртуальные машины, сети, наличие firewall и еще несколько <a href="https://azure.microsoft.com/en-us/documentation/articles/security-center-policies/">моментов </a>).
<cut text="Давайте посмотрим, что он может." />
Для начала, задеплоим что-нибудь в Azure. Я для тестов буду использовать этот <a href="https://github.com/msftrupfe/ARM/tree/securityPost">ARM шаблон.</a> Он в себя включает приложение с 3 слоями: 
<ul>
	<li>1-N виртуальных машин в веб слое (windows server 2012r2), </li>
	<li>1-N виртуальных машин в слое бизнес-логики (windows server 2012r2), </li>
	<li>1-N в слое данных (SQL server на windows server 2012r2). </li>
	<li>Виртуальные машины в availability группах. </li>
	<li>1 сеть, с 3 подсетями (1 между базой и логикой, 1 между логикой и вебом и одна, по сути, DMZ). Каждая подсеть содержит свою network security group, в которой определены inbound/outbound security rule (считайте для простоты, что правила для firewall, которые либо разрешают трафик на определенные ip, либо запрещают). </li>
</ul>
Визуально как-то так:

<img align="center" width="650" src="https://habrastorage.org/files/80c/1ee/08a/80c1ee08af90463c99a423889e6b411f.png"/>

<img align="center" src="https://habrastorage.org/files/b8b/779/bc5/b8b779bc58a348bb9a8ff0f1378b615c.png"/>
Теперь давайте включим сбор данных для security center:

<img align="center" width="650" src="https://habrastorage.org/files/c5c/9e2/d44/c5c9e2d44e4b41e2b6f04fbcadff4875.png"/>
Security Center создаст для сбора данных resource group и storage account.

<img align="center" width="650" src="https://habrastorage.org/files/fea/b91/01d/feab9101d063480b877dc421ad7d8835.png"/>
Вы заметите, что у меня таких 2 группы. Это потому, что у меня 2 подписки и данные собираются для каждой подписки отдельно.

Давайте откроем Blade с Security Center и посмотрим, как все плохо.

<img align="center" src="https://habrastorage.org/files/58d/18d/86d/58d18d86da9c44b5a509c41c58e8658b.png"/>
Я, в целом, догадывался, что у меня дыра в безопасности (хорошо, что хоть что-то в безопасности), но выглядит как-то совсем печально, и надо разбираться.

<h3>Applications</h3>
Начнем с вкладки Applications
Я не совсем согласен с картинкой, которую использовала продуктовая команда, но суть понятна: где ваш firewall перед public ip вашего приложения?

<img align="center" width="800" src="https://habrastorage.org/files/b50/b31/07d/b50b3107d5a84d3483c6f03c1a87c7ba.png"/>

Сразу предлагается фикс – добавить firewall от внешнего вендора (не спешите его добавлять, почитайте про его возможности, про цены, может быть, вам этот public ip и не нужен). Как и любая другая ошибка, найденная роботом, она должна быть обдумана человеком, и я лично решил проигнорировать её, и, чтобы она мне глаза не мозолила, сделал dismiss

<img align="center" width="800" src="https://habrastorage.org/files/245/10a/8b2/24510a8b2938401080a2cf3ac0e9f94b.png"/>

<h3>VM</h3>
Давайте посмотрим, что там с виртуальными машинами-то

<img align="center" width="800" src="https://habrastorage.org/files/9c8/bd7/fc0/9c8bd7fc0cc840ef85cf24fef46ab047.png"/>

Опять печально, но по всем 3 машинам есть потенциальные проблемы: диски нешифрованные (в azure только disk c может быть зашифрован bitlocker-ом), обновлений не хватает, антивируса нет. Для некоторых проблем можно прям сразу нажать на кнопку «решение». Например, установить антивирус в машину.

<img align="center" width="800" src="https://habrastorage.org/files/ed7/bbd/275/ed7bbd2754c0425fa96ccbd0c5283304.png"/>

Жмем кнопку «создать» и будем считать, что мы стали чуть-чуть безопаснее.

<h3>Virtual Networks</h3>
Ну и самое важное – сеть. Давайте посмотрим, что же security center не нравится в конфигурации моих подсетей.

<img align="center" width="800" src="https://habrastorage.org/files/ed5/fef/76e/ed5fef76e73e4b3493215a43aa6d1b32.png"/>

Ну, понятно: правила, по сути, разрешают всем, кому не лень, отсылать трафик на любой ip в моей подсети, и это никак не блокируется. Согласен, проблема, и надо правила конфигурировать. 

Я решил, что доступ к RDP я разрешу только из моей виртуальной сети.

<img align="center" width="800" src="https://habrastorage.org/files/5c2/1c1/ec9/5c21c1ec95124fb58b36d8b3af692076.png"/>

<img align="center" width="800" src="https://habrastorage.org/files/bc5/aea/e4f/bc5aeae4f866469c8863ba798c406f2d.png"/>

<b>Не скажу, что я закрыл все дыры, но спасибо, что security center указал мне на самые базовые вещи, которые я быстро смог закрыть, чтобы хоть самые очевидные дары в безопасности закрыть.</b>

Что вообще умеет проверять Security Center? Да мы по сути все и разобрали, кроме вещей связанных с sql. Еще SC умеет проверять <a href="https://msdn.microsoft.com/en-us/library/dn948096.aspx">включено ли шифрование на SQL</a> , и <a href="https://azure.microsoft.com/en-us/documentation/articles/sql-database-auditing-get-started/">включен ли Audit на SQL</a>. 

Для preview сервиса, по-моему, не плохо. Есть пожелание что добавить? Вам <a href="https://feedback.azure.com/forums/216840-security-and-compliance">сюда </a>