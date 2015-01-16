<img src="http://habrastorage.org/files/773/a40/ab1/773a40ab12be4e9e89d8947fc934efd7.png" alt="image"/>
Буквально 8 января был выведен в стадию preview новый сервис Azure Key Vault.

<b>Azure  Key Vault это - HMS as a Service </b>(<a href="http://en.wikipedia.org/wiki/Hardware_security_module">Hardware security module</a>). HMS - это выделенное hardware, которое позволяет <b>хранить, управлять ключами/секретами и шифровать/расшифровывать, ставить/проверять подписи</b> максимально безопасным образом и достаточно быстро (специфичное железо, заточенное под шифрование, по заявлениям работает быстро, но на сколько или какие делались замеры- информации нет). Ранее KV был известен как BYOK (bring-your-own-key).
<habracut>

<h4><b>Теоретическая часть</b></h4>
Для понимания концепции нужно глянуть на несколько схем и это <a href="http://channel9.msdn.com/Blogs/Windows-Azure/Azure-Key-Vault-Developer-Quick-Start">видео</a>.
В концепции есть 3 выделенных роли.
<ol>
	<li>Те, кто занимаются ключами.</li>
	<li>Те, кто пишет софт, который использует ключи.</li>
	<li>Те, кто следит за результатами работы приложений с ключами.</li>
</ol>
Из моего опыта: первые и третьи в 90% случаях сидят в одном и том-же отделе информационной безопасности, причем третьи смотрят за логами не через призму сопровождения и эксплуатации конкретных приложений, а вообще про использование криптографии. Microsoft выделила 3 роли, т.к. аудитор должен быть независимым от всей остальной компании, чтобы делать независимые оценки.

<h5><b>Для понимания механизма работы нам понадобятся еще 2 схемы</b></h5>
Схему нужно читать справа налево. Администратор создает в Azure Active Directory приложение, загружает в Key Vault ключи/секреты.  Для упрощения считаем, что реальное приложение уже написано. Приложение, аутентифицировавшись в AAD, выполняет работу с шифрованием через Key Vault, используя полученный при авторизации токен.
<img src="http://habrastorage.org/files/8b2/f32/d1e/8b2f32d1e76a4ce789a93a5454efd36f.png" alt="image"/>

Ниже на схеме показано что может делать каждая роль с key vault.

<img src="http://habrastorage.org/files/5a4/880/0d6/5a48800d68f040f2a58ba018d1c2fadd.png" alt="image"/>

Как реально все это выглядит через Management Portal можно посмотреть в <a href="http://azure.microsoft.com/en-us/documentation/articles/key-vault-get-started/">этой</a >и <a href="http://blogs.technet.com/b/kv/archive/2015/01/09/azure-key-vault-step-by-step.aspx">этой</a> статье, либо в видео.
Мне не хочется копипастить и к каждому пункту прикладывать powershell команду, их можно прочесть из статьи оригинала, но пример приложу:
<img src="http://habrastorage.org/files/be5/a21/312/be5a21312d32487992c2e453afe9c814.png" alt="image"/>

<h5><b>Использование для шифрования</b></h5>
При создании Key Vault мы его как-то назвали. На пример mykeyvault.
Мы создали ключ, который будем использовать в примере key-name. У ключа может быть несколько версий (старая версия).
В URL мы должны указать тип операции, которую мы делаем. В примере sign- подпись.
Затем в теле сообщения в виде json передаем 2 параметра: алгоритм и текст, который мы хотим обработать.
<img src="http://habrastorage.org/files/d69/54c/8bd/d6954c8bd25f47e09ef36ce00aa6d8bc.png" alt="image"/>

В ответ мы получим идентификатор ключа и подписанный текст.

<img src="http://habrastorage.org/files/bcd/ff7/baa/bcdff7baa59d472eb733156de2090efb.png" alt="image"/>

<h5><b>API</b></h5>
Про API, как всегда, особо разговаривать нечего. Microsoft всегда выпускает API ко всем своим сервисам, при этом сам Azure портал использует этот API для доступа.
Список методов- стандартный для шифрования:
<img src="http://habrastorage.org/files/067/189/2f1/0671892f10f4405295828c5aceae15fd.png" alt="image"/>

У Вас есть 2 варианта работылибо самим написать клиент используя соответствующую документацию, либо использовать готовый <a href="http://msdn.microsoft.com/library/azure/dn903628">.net клиент</a>  и <a href=" http://msdn.microsoft.com/library/dn868052.aspx">powershell командлеты</a> (сам .net клиент понятное дело в powershell не нуждается). Есть кое-какие <a href="http://www.microsoft.com/download/details.aspx?id=45343">примеры</a> работы.

<h5><b>API VERSION</b></h5>
API Version - это параметр, его текущее значение - «2014-12-08-preview». 
Для тех, кто часто работает с API, необходимость этого параметра и проблемы при его отсутствии очевидны. 
Как нетрудно догадаться, в мире нет ничего совершенного, и версия будет меняться, а сам API - становиться несовместимым. Разработчик, единожды написав код, планирует, что он будет работать вечно и далее редко следит за обновлениями сервиса, если по коду нет задач на доработку. Явное указание версии позволит контролировать эти изменения и не споткнуться об автообновление, когда мы ничего не меняли, а нас обвинят в поломке приложения.

<h5><b>Ошибки</b></h5>
О произошедших ошибках можно будет понять 3 способами.
<ul>
	<li>HTTP код ответа. Тут как всегда- 2** - хорошо, 3** -  стоит обратить внимание, 4** -  проблемы с авторизацией, 5** - azure плохо.</li>
	<li>В возвращаемом json может быть описание проблемы 
<img src="http://habrastorage.org/files/c29/590/1f7/c295901f7e01458782f0955fde231608.png" alt="image"/></li>
	<li>аудит</li>
</ul>

<h5><b>Аудит</b></h5>
Смысл аудита в том, чтобы видеть откуда какое приложение и какие ключи использует, когда оно это делало, а также ошибки.
Команда KV заявляет, что скоро будет доступна возможность мониторинга и аудита использования ключей, быстрый анализ на основе Hadoop... НО в данный момент этого нет. 

<h5><b>Железо</b></h5>
Какие конкретно железки стоят в azure не раскрывается, однако, подчеркивается, что они соответствуют американскому стандарту <a href="http://en.wikipedia.org/wiki/FIPS_140">FIPS_140-2</a> (есть 3 версия стандарта от 2009 года) level 2 (всего 4 уровня, 4 самый жесткий.). 

<h6><b>В чем я вижу огромный плюс этого сервис для разработчика</b></h6>
Работа с криптографией вынесена из вашего приложения в отдельный, доступный через web-api сервис, не на вашем сервере. Key Vault потенциально снимет кучу головной боли с разработчика (если вы можете использовать его в своем приложении по техническим характеристикам, и это не противоречит политическим мотивам). 
Те, кто занимался криптографией на .net в Российских реалиях, не дадут соврать, что достаточно часто шифрование - это какие-нибудь подключаемые нативные библиотеки, которые работают часто только под 32-битной операционной системой, не старше чем какой-нибудь windows xp sp3. И тут либо ты сам выносишь шифрование в виде веб-сервиса и получаешь полный комплект радости от новой сущности (ее же надо мониторить, обучить работать с нею сопровождение, получить еще одну потенциальную точку отказа), либо вынужден согласиться использовать в 2014 году xp sp3 на 32-битной OS.
Еще хуже, когда шифрование предоставлено в виде программы .exe с командным интерфейсом, и приходится еще думать, как с ней взаимодействовать правильно, чтобы при этом выдерживать SLA.

<h6><b>В чем отделу информационной безопасности(ИБ) выгода?</b></h6>
На мой взгляд, отделу ИБ будет на порядок проще управлять ключам шифрования (создавать, отзывать), если они не будут раскиданы по десяткам серверов, а будут собраны в едином Key Vault. Как минимум, ключи нужно периодически менять (0.5-1 года) и сделать это на куче серверов - это обезьянья работа.

На уровне key vault можно ограничивать использование приложениями/пользователями разных ключей и типы операций, которые они могут делать. 
Пример: пришел нам из Центрального банка архив, мы знаем, что на нем должна быть подпись, а на каждом файле в архиве - шифрование и авторизация. Соответственно, мы даем приложению, которое работает с этими файлами, права на расшифровку и проверку подписи, но не даем права на шифрование этим ключом и установку подписи и, тем самым, снижаем вероятность неверного использования.
<b>Уверен, что отдел ИБ найдет десяток причин не использовать Key Vault если захочет, но это их работа - никому не доверять.</b>

<h5><b>Цены:</b></h5>
Более детально можно узнать из <a href="http://azure.microsoft.com/en-us/pricing/details/key-vault/">статьи</a>, особенно прочитав FAQ в конце статьи, а я расскажу основную мысль.
Есть 2 тарифных плана: standard, premium и есть всего 2 фичи, за которые берутся деньги. 1- это операции с использованием ключей, а 2- это хранение ключей в HSM. В итоге 2 плана отличаются тем, что в плане standard нет хранения ключей в HSM. 
<img src="http://habrastorage.org/files/ba9/91b/285/ba991b2859f04e9188bf369f77a9e399.png" alt="image"/>

<b>«Что такое операция?»</b> - это первый возникающий вопрос! Процитируем:
“Every successfully authenticated REST API call counts as one operation. Examples of operations for keys: create, import, get, list, backup, restore, delete, update, sign, verify, wrap, unwrap, encrypt and decrypt. Examples of operations for secrets: <a href="http://msdn.microsoft.com/en-us/library/azure/dn903630.aspx">create/update, get, list.</a>”  
Говоря русским языком, это операции с ключами и секретами (создание ключей, обновление, шифрование, проверка подписей и т.д.).

И еще один хороший, вопрос: <b>«А если ключи выпустил не я, а другой подписчик Azure, то кто платит?»</b> Ответ: тот, кто выпустил, а не тот, кто пользуется.

<h5><b>Ссылки:</b></h5>
<ul>
	<li><a href="http://azure.microsoft.com/en-us/services/key-vault/">Стартовая</a></li>
	<li><a href="http://azure.microsoft.com/en-us/documentation/services/key-vault/">Стартовая для документации</a></li>
	<li><a href="http://blogs.technet.com/b/kv/">Блог команды авторов</a></li>
	<li><a href="http://channel9.msdn.com/Blogs/Windows-Azure/Azure-Key-Vault-Developer-Quick-Start">Видео о том, что это такое.</a></li>
	<li><a href="https://social.msdn.microsoft.com/forums/azure/en-US/home?forum=AzureKeyVault">Forum</a></li>
	<li><a href=" http://blogs.technet.com/b/kv/archive/2015/01/12/using-the-key-vault-for-sql-server-encryption.aspx  http://msdn.microsoft.com/library/dn198405.aspx">Использование Key Vault в SQL сервер</a></li>
	<li><a href="http://msdn.microsoft.com/en-us/library/azure/dn903625.aspx">Стартовая страница документации на MSDN</a></li>
</ul>