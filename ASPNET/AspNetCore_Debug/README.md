“Если Вы умеете писать код- это еще не значит, что вы умеете его отлаживать” – этой фразой один из гуру windbg любит начинать тренинги. 
С Asp.Net в общем, и с MVC в частности ситуация была очень похожая- код не работает, и без stackoverflow разобраться почему редко удается. А все почему?!
<ul>
	<li>Сначала исходных кодов к asp.net не было в публичном доступе.</li>
	<li>Затем код появился на codeplex, но тяжело было привязать свою ошибку к этому исходному коду и часто приходилось отлаживаться методом пристального вглядывания. </li>
	<li>Опытные разработчики конечно знали, как найти нужную версию pdb файлов, как указать visual studio где лежат исходные коды, или на крайний случай можно было декомпилировать dll. </li>
</ul>
Так вот, с asp.net 5.0 для начала отладки в исходном коде нужно меньше 5 минут. Сейчас весь исходный код на <a href="https://github.com/aspnet">github </a>, и что еще важнее его можно добавить в свой проект и скомпилировать.
<img src="https://habrastorage.org/files/e53/461/a90/e53461a90e724c2dbd8ab439c1da6c51.png"/>
<cut>
Пример: создаем самое просто Web API. 1 контроллер, StartUp класс и конфиг с зависимостями на project.json. Я как старый MVC разработчик начал искать- а где же у меня routes сконфигурирован. Не понимаю!
<img src="https://habrastorage.org/files/05b/d15/7b4/05bd157b459b4706a6bd7e4f35b870f1.png"/>

Мои дальнейшие действия: у меня всего 2 вызова AddMVC и UseMVC, оба они в сборке MVC. 
<b>Как посмотреть?!- да проще простого! </b>
<ul>
	<li>Делаем clone репозитария git clone https://github.com/aspnet/Mvc </li>
	<li>Смотрим какая версия указана у нас в коде- 6.0.0-beta8. Проверяем, что такая версия есть в нашем коде через git tag. </li>
	<li>Если такую версию нашли- то делаем git checkout 6.0.0-beta8.
<img src="https://habrastorage.org/files/911/d51/d77/911d51d77c034643b272132ca75541fc.png"/>
</li>
	<li><spoiler title="Затем добавляем исходные коды прямо в наш проект в файл global.config"><img src="https://habrastorage.org/files/e3a/219/4ee/e3a2194eefc84029a44a98651c531ef9.png"/></spoiler> </li>
	<li><spoiler title="Сначала вставляем в него стандартный код "><img src="https://habrastorage.org/files/7ba/860/4d7/7ba8604d75944c7abaf96951500c2acc.png"/></spoiler></li>
	<li>А затем добавляем скаченный с github код mvc 
<img src="https://habrastorage.org/files/04b/f6f/e9a/04bf6fe9a4df43b8af0ec0497200d991.png"/> </li>
	<li><spoiler title="Нажимаем кнопку Restore Packages"><img src="https://habrastorage.org/files/64d/e69/9e9/64de699e9ced4ef18ddc6c253cb4c098.png"/></spoiler> </li>
	<li><spoiler title="Проверяем, что все прошло хорошо в окне output"><img src="https://habrastorage.org/files/cb0/847/ffa/cb0847ffaa684bf49014115571ca5c74.png"/></spoiler></li>
	<li>Ну и теперь мы можем из нашего кода, перейти в код mvc и увидеть, где у нас конфигурируются routes! 
<img src="https://habrastorage.org/files/9ef/c68/e7a/9efc68e7adae4b48a5a9c1d70d7cf97d.png"/></li>
</ul>
<h5><b>Всем приятной отладки!</b></h5>