Летом 2014 года Microsoft выпустила фичу к Azure, которая называется StorSimple, и о ней 2 раза вкратце писали на хабре <a href="http://habrahabr.ru/company/microsoft/blog/240141/">тут</a> и <a href="http://habrahabr.ru/company/microsoft/blog/232239/">тут</a>. Я прошляпил это обновление, как, наверно, и большинство из нас, и сейчас попробую наверстать упущенное.

Основная идея сервиса - <b>расширить локальное <a href="http://storsimple.seagate.com/storsimple-solution-family">StorSimple хранилище</a> своей компании за счет Azure</b>. У вас на площадке стоит хранилище, и вы к нему подключаете Azure. Частота доступа к различным хранящимся данным неоднородна, есть те, к которым обращаются часто, есть те, к которые можно годами не трогать, но хранить их по различным причинам надо. 
<img src="http://habrastorage.org/files/14d/1cf/0ee/14d1cf0ee13f40f88da8e243fbcadd17.png" alt="image"/>
К тем данным, которые вы используете часто, доступ будет на локальные SSD диски, к менее востребованным - на HDD диски и к очень редко используемым - в Azure. При этом ваше хранилище само ведет статистику доступа и переносит данные в azure для долговременного хранения. 

<habracut>

<img src="http://habrastorage.org/files/1b2/0cd/6ec/1b20cd6ecd9544d4b4034fa45dd905fe.png" alt="image"/>
Базовая идея не нова, на основе нее была построена иерархия памяти в компьютерах (регистры, кэши процессора, оперативная память, диски, сеть…), уже давно реализована в хранилищах данных в виде разделения данных между SSD/HDD в зависимости от частоты использования. Теперь же Microsoft расширила хранилища до своего облака.

<u>На мой взгляд название StorSimple не совсем подходит к этой фиче, т.к. не такая уж она и простая внутри, да и ничего простого за 100к$ быть не может. Но это мое личное мнение.</u>

<h5><b>Порог входа</b></h5>
Минимальный порог входа - <b>у вас уже есть хранилище от <a href="http://storsimple.seagate.com/storsimple-solution-family">Microsoft/SeaGate</a></b>. Согласитесь, порог уже не маленький, стратапу с разбегу не потянуть 100 000$, которые стоит хранилище. 
<img src="http://habrastorage.org/files/a98/342/621/a98342621e0d4e8aa71f97b9bf085266.png" alt="image"/>
<img src="http://habrastorage.org/files/235/fea/7bd/235fea7bde71409f95e64e6c976c7ef5.png" alt="image"/>

<spoiler title="Чтобы получить Azure StorSimple, нужно запросить доступ, заполнив форму">
<a href="http://www.controlyourstorage.com/?WT.mc_id=RI_SS_Awareness_TectTarget1MsgUnitSCS">форма</a>
<img src="http://habrastorage.org/files/3f8/b6d/101/3f8b6d101ba44d688ffb652cfecc1a04.png" alt="image"/></spoiler>
Это совершенно не похоже на то, как другие сервисы получались в azure, но цены на сами девайсы многое объясняют.

Дополнительное ограничение - это <b>необходимость использовать <a href="http://azure.microsoft.com/en-us/pricing/enterprise-agreement/">Enterprise Agreement.</a></b> Это не сильное ограничение, т.к. вряд ли большая серьезная компания зарегистрирована как фрилансер из Бангалора.

И самое “важное” ограничение: у Вас должны быть сильные программисты, т.к. хранилище серии 8100-8700 весит от 27 до 31кг и поставляется в собранном виде. Чтобы его привезти и смонтировать, девушки с ресепшена не хватит, и Microsoft заботливо даже <a href="http://msdn.microsoft.com/en-us/library/dn772327.aspx">инструкцию по распаковке коробки</a> написало и <a href="http://msdn.microsoft.com/en-us/library/dn757749.aspx">монтажа в серверный шкаф</a>.

<h5><b>Разворачивание локального StorSimple Device</b></h5>
Прежде чем начинать развертывание, нужно к нему подготовится и <a href="http://msdn.microsoft.com/en-us/library/dn772392.aspx">собрать данные</a> для подключения Azure  (IP адреса, аккаунты в azure и т.д.)

Кроме того, проверить требования к <a href="http://msdn.microsoft.com/en-us/library/dn772360.aspx">доступности</a> и <a href="http://msdn.microsoft.com/en-us/library/dn772371.aspx">открыты ли порты</a>. 

Microsoft написала очень <a href="http://msdn.microsoft.com/en-us/library/dn757754.aspx">подробную-пошаговую инструкцию по развертыванию</a>, которую надо прочесть и выполнить. В ней 8 шагов.
<ol>
	<li><a href="http://msdn.microsoft.com/en-us/library/dn772408.aspx">Создать в Azure сервис StorSimple</a>
<spoiler title="Как-то так"><img src="http://habrastorage.org/files/c3d/882/d80/c3d882d809a048f990614051bbf343ff.png" alt="image"/></spoiler>
</li>
	<li><a href="http://msdn.microsoft.com/en-us/library/dn772346.aspx">Сгенерировать ключи для сервиса</a>
<spoiler title="Как-то так">
<img src="http://habrastorage.org/files/8c9/aaf/a50/8c9aafa50f774a68882421dd6cde96e8.png" alt="image"/>
<img src="http://habrastorage.org/files/c03/a99/be0/c03a99be01024bcc97e9b405a9aafcf3.png" alt="image"/></spoiler>
</li>
	<li><a href="http://msdn.microsoft.com/en-us/library/dn772337.aspx">Зарегистрировать девайс в Azure</a></li>
	<li><a href="http://msdn.microsoft.com/en-us/library/dn772407.aspx">Настроить девайс в Azure</a>
<spoiler title="Как-то так">
<img src="http://habrastorage.org/files/ca0/a13/07a/ca0a1307ac0549cbb5698c03f8199837.png" alt="image"/>
<img src="http://habrastorage.org/files/05b/33d/b5f/05b33db5f89f497ba6f16b262680e7cb.png" alt="image"/>
</spoiler>
</li>
	<li><a href="http://msdn.microsoft.com/en-us/library/dn772386.aspx">Создать Volume Container</a></li>
	<li><a href="http://msdn.microsoft.com/en-us/library/dn772357.aspx">Создать Volume(раздел), указав размер</a>
<spoiler title="Как-то так"><img src="http://habrastorage.org/files/eb8/b3b/ce8/eb8b3bce8e7843c2bd21fca514557744.png" alt="image"/></spoiler>
</li>
	<li><a href="http://msdn.microsoft.com/en-us/library/dn757765.aspx">Смонтировать раздел, отформатировать его</a></li>
	<li><a href="http://msdn.microsoft.com/en-us/library/dn772364.aspx">Сконфигурировать Backup</a></li>
</ol>

<h5><b>Мониторинг и администрирование</b></h5>
Большую часть своей карьеры я занимался вопросами со стороны разработки, но даже разработчику становится интересно почитать руководства для администрирования <a href="http://msdn.microsoft.com/en-us/library/749298c4-b5b3-4924-9d4f-ac9aac259642">1</a>, <a href="http://msdn.microsoft.com/en-us/library/e6986299-edcb-4fc3-92f1-7132665001b4">2</a>
и что можно сделать с сервисом через Azure portal. Это нужно, как минимум, чтобы в случае возникновения проблем, вместе с сопровождением и админами разбираться что произошло и что может произойти.
Какие графики для мониторинга есть? Какие оповещения? Что и где можно посмотреть? Ниже пример графика мониторинга и какие есть <a href="http://msdn.microsoft.com/en-us/library/dn772370.aspx">ограничения</a>.
<img src="http://habrastorage.org/files/bbb/b30/db5/bbbb30db5202407499810ef6c63927b1.png" alt="image"/>
<spoiler title="И еще пару график+ оповещения">
<img src="http://habrastorage.org/files/3c9/e24/f9c/3c9e24f9cdbf409fbc51dabdf7ba365e.png" alt="image"/>
<img src="http://habrastorage.org/files/798/c43/a9b/798c43a9b6fa4a5b8774302fd4b5e23a.png" alt="image"/>
</spoiler>

Если вам совсем интересно, то стоит почитать и <a href="http://msdn.microsoft.com/en-us/library/1f6b7bb8-ae28-4f2e-893f-d2f1cf8a8c62">руководство для тех, кто занимается железом</a>, но лично мне сильно более интересна cloud составляющая, поэтому я ее пролистал. Хотя, если интересно как менять диски, системы охлаждения, понимать индикацию на корпусе, то раздел явно для Вас.

<h5><b>Безопасность</b></h5>
Не знаю, как в других странах, а в России при любых поползновениях-обсуждениях переноса своих данных в облако задаются тысячи вопросов по безопасности хранения данных и т.п. Мы ничего не можем поделать, Azure находится вне границ Российской Федерации, и мы должны серьезно подумать, есть ли среди хранимых нами данных что-нибудь важное типа персональных данных. Я не вижу смысла обсуждать политические вопросы хранения данных в StorSimple, но технические очень даже неплохо описаны в <a href="http://msdn.microsoft.com/en-us/library/dn757752.aspx">документации</a>.
Весь трафик шифрованный, данные хранятся в <a href="http://msdn.microsoft.com/en-us/library/dn757731.aspx">шифрованном</a> виде. Microsoft больше переживает за безопасность физического девайса на стороне клиента, т.к. там и данные часто используемые, и как построена система безопасности знает только сам клиент.

<h5><b>SharePoint/Hyper-V/VMware</b></h5>
Типовыми производителями большого объема данных можно считать Hyper-V и VMware-ESX. Множество образов дисков золотых/обычных, snapshots лежат на дисках, и часть из них редко используется. К Hyper-V и VMware-ESX можно подключить Volume из StorSimple и дальше все сделает хранилище.
<spoiler title="Hyper-V"><img src="http://habrastorage.org/files/5fb/1da/936/5fb1da93624949c0b6ba09e7b374c73b.png" alt="image"/></spoiler>  
<spoiler title="VMware"><img src="http://habrastorage.org/files/fd5/53d/a36/fd553da36add4261bc9583e13a1a893d.png" alt="image"/></spoiler>
С SharePoint немного сложнее. Надо <a href="http://msdn.microsoft.com/en-us/library/dn757737.aspx">скачать адаптер</a> и <a href="http://msdn.microsoft.com/en-us/library/dn757747.aspx">поставить его</a>.
<img src="http://habrastorage.org/files/212/95a/53e/21295a53e9b743de8fd58a6a71aecc54.png" alt="image"/>

<h5><b>P.S.</b></h5>
<b>Не скажу, что для России очень актуально такое расширение хранилища, с учетом что надо еще купить определенный тип хранилища, но для общего развития поинтересоваться стоит.</b>

<h5><b>Ссылки</b></h5>
<ul>
	<li><a href="http://azure.microsoft.com/en-us/services/storsimple/">Стартовая описания сервиса</a></li>
	<li><a href="http://azure.microsoft.com/en-us/documentation/services/storsimple/">Стартовая страница документации</a></li>
	<li><a href="https://www.youtube.com/watch?v=Xxi6FBJQA_M&feature=youtu.be">Видео обзор</a></li>
	<li><a href="http://www.esg-global.com/lab-reports/microsoft-storsimple-8000-series-array/">Много умных слов на тему использования с Hyper-V/VMWare</a></li>
	<li><a href="http://blogs.technet.com/b/cis/">Блог команды разработчиков</a></li>
	<li><a href="http://feedback.azure.com/forums/257791-storsimple">Голосование за фичи</a></li>
	<li><a href="http://onlinehelp.storsimple.com/">Help по хранилищу</a></li>
	<li><a href="http://msdn.microsoft.com/en-us/library/dn757725.aspx">Терминология</a>. Полезно почитать, чтобы говорить на одном языке и уменьшить риск непонимания. </li>
</ul>

Если Вы хотите помочь улучшить статью- предлогайте ваши правки через <a href="https://github.com/SychevIgor/blog/tree/master/Azure/Data%26Storage/StoreSimple">github</a>