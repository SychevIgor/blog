<h4>Что есть (было)</h4>
Есть SVN сервер, и довольно старый – 2008 года. Обновлять его опасаются: «мало ли что». Бэкапы-не бэкапы, создать себе проблему и героически из нее выходить не хочется.

<h4>Что хочется (есть)</h4>
Осовременить средства и методики разработки. Как минимум – получить возможность делать локальные комиты. В итоге решили перейти на Git. С Git у некоторых людей в команде был опыт, причем хороший, и поэтому решили всерьез и не думать о других распределенных системах.

<h4>Чего при этом не хочется</h4>
Не хотелось заморачиваться администрированием, не хотелось «менеджерить» из консоли права. Ну и лично мне не хотелось лезть в дебри Linux (не религии ради, а просто есть еще и другие задачи, да и в команде почти все на Windows сидят), плюс из свободных у нас были только Windows машины.

<habracut>

<h4>Поиск решения на Windows</h4>
Я  прочел много разных статей на тему Git Server on Windows. Общая картина удручает: как-то сложно все, где-то – наполовину мертво, где-то – без  GUI. <a href=" http://habrahabr.ru/post/199144/">Вот из местных русскоязычных статей</a> есть небольшой список проектов:. Я честно попробовал рекомендованный автором ITeF!X и, видимо, у меня руки не из того места росли, но я не осилил(То прав не хватало на создание аккаунта, то putty закэшировало в реестре публичный ключ сервера, а я его сменил.). Ну и, честно говоря, уровень GUI – просто отстой, привет Windows 95.
В итоге, мы-таки решились поставить TFS2013 и Git и мигрировать код. Можно почитать статью Димы Андреева на тему <a href="http://habrahabr.ru/company/microsoft/blog/167699/">плюшек TFS2013 и Git</a>:   Большая часть наших разработчиков не на .net пишут, поэтому интеграция с Visual Studio совершенно не интересно.

<h4>Шаг Ноль. Миграция в локальный репозиторий.</h4>
Сама по себе миграция кодов - это 1 команда – git svn clone, и затем push. Разбирать сами команды смысла не имеет. Важно что git  svn clone выкачивает коды из svn репозитария и складывается в локальный git. 
Из GUI как-то приятнее работать, поэтому я воспользовался GitExtensions. 


<spoiler title="Клонируем SVN в Git локальный.">"C:\Program Files (x86)\Git\bin\Git.exe" SVN clone "SVN://SERVERNAME/SubfolderName" "C:/Users/sycheviy/desctop/MyPath"
Файл с пользователями составлять не нужно было, т.к. в  SVN сами по себе пользователи брались из ActiveDirectory и их имена были понятны и так.<img src="http://habrastorage.org/getpro/habr/post_images/5da/50b/96e/5da50b96e61321e0ac75bf9f983fe926.jpg"/></spoiler>
Ошибок не возникло, однако 2000+ комитов, достаточно больших, с медленного сервера вытягивались долго. 
Локально копию кода мы имеем. Дальше ее можем куда угодно push, ну а мы будем в TFS.

<h4>Шаг первый. TFS.</h4>
<spoiler title="Поставили TFS на Windows Server 2008r2."><img src="http://habrastorage.org/getpro/habr/post_images/c34/25d/c94/c3425dc94cd2da8d71633ba86487f7c3.jpg"/></spoiler>
Запустить - согласиться с лицензией - готово. Даже как-то не интересно.

<h4>Шаг второй. SQLServer.</h4>
Дальше разобрались с 3 мелкими моментами с SQLSERVER при конфигурации.
SQLServer 2012 SP1- это минимальная версия, с которой можно работать на TFS2013. Пришлось поставить;
Разобрались с правами на уровне OS (серьезная контора, права порезаны);
Разобрались с collation, который у нас по умолчанию при установке был неверный; Требуется, чтобы Collation сервера был CI_AS Case- insensitive, ascent sensitive. 
Мы решили проблему без перестановки сервера.  <a href="http://blogs.technet.com/b/servicemanager/archive/2012/05/24/clarification-on-sql-server-collation-requirements-for-system-center-2012.aspx">В статье</a> есть раздел про кодировки и смысл этих постфиксов.
<a href="http://technet.microsoft.com/en-us/library/ms179254.aspx">Команда изменения collation</a>

<h4>Шаг третий. Настройка TFS.</h4>
Мы установили TFS, но еще ничего не настроили. <spoiler title="Открываем консоль управления TFS"><img src="http://habrastorage.org/getpro/habr/post_images/8a7/429/9a9/8a74299a9807a69a861bd3c334dca964.jpg"/></spoiler>
<spoiler title="Выбираем тип конфигурации.">Я не стал усложнять сильно и выбрал базовый.<img src="http://habrastorage.org/getpro/habr/post_images/77b/141/e96/77b141e960f505281f9ca89dcad217c9.jpg"/></spoiler>
<spoiler title="Выбрали сервер баз данных который будем использовать для хранения пользователей и тп."> 
<img src="http://habrastorage.org/getpro/habr/post_images/881/93f/4b8/88193f4b8a1c0bcf90e1faf4945d30f7.jpg"/></spoiler>
<spoiler title="Взглянули на список параметров получившийся."><img src="http://habrastorage.org/getpro/habr/post_images/5b6/bd3/959/5b6bd3959c351de92ad9d18a29a26292.jpg"/></spoiler>
<spoiler title="Нажали проверить"> - если с базой будут проблемы, тут мы и получим сообщение о проблеме.
Визард проверил можно ли такие настройки применить в принципе, но он их еще не применял.<img src="http://habrastorage.org/getpro/habr/post_images/09d/46e/abf/09d46eabf21fa287674bad0a9132e29f.jpg"/></spoiler>
 Осталось только нажать Configure.
<spoiler title="Проверяем что приложение появилось в iis.">Должен был появиться сайт.
<img src="http://habrastorage.org/getpro/habr/post_images/c4c/0ab/95a/c4c0ab95ac9c13b167c5f3840b42ab22.jpg"/></spoiler>
<spoiler title="И проверяем что в базе все было создано"><img src="http://habrastorage.org/getpro/habr/post_images/83f/d2e/22e/83fd2e22e8c6fb5b2109cb9cc2d797db.jpg"/></spoiler>
На выходе у нас есть TFS сервер, есть сконфигурированная база, есть веб портал администрирования. Все, что я хотел, в принципе.
<spoiler title="Как бонус портал, на котором можно управлять пользователями, группами, смотреть код и так далее."><img src="http://habrastorage.org/getpro/habr/post_images/89d/aeb/868/89daeb86841d85574cd79cabcc8c83c3.jpg"/></spoiler>

<h4>Шаг Четвертый. Создание Project Collection. </h4>
Хотя можно использовать и Default, но я люблю более осмысленные названия.
<spoiler title="Создание ProjectCollection"><img src="http://habrastorage.org/getpro/habr/post_images/db0/3bc/4c5/db03bc4c51f3cb6e916ce2ce1c47a07d.jpg"/>
<img src="http://habrastorage.org/getpro/habr/post_images/43d/ce0/e84/43dce0e84a821c4a2918756d0d829a8d.jpg"/>
<img src="http://habrastorage.org/getpro/habr/post_images/98c/846/fe1/98c846fe146cf0bb7253c408f265ca4d.jpg"/>
<img src="http://habrastorage.org/getpro/habr/post_images/2bd/2b0/e92/2bd2b0e92e26980944896ca836b5f3bf.jpg"/></spoiler>


<h4>Шаг Пятый. Создание проекта.</h4>
Нужно создать проект, в котором будут храниться исходники и к которому будут привязаны пользователи. Идем в Visual Studio2013 (из 2012 вроде как нельзя создать Git-проект).
<spoiler title=" подключаемся к TFS серверу"><img src="http://habrastorage.org/getpro/habr/post_images/c87/cfb/31b/c87cfb31b952d7d15eccc7e9ba8e20ba.jpg"/></spoiler>
<spoiler title="создаем team project">Возможно, можно как-то еще, но я сделал первым попавшимся методом.
<img src="http://habrastorage.org/getpro/habr/post_images/4c6/4f7/8fc/4c64f78fc391440fc4f6dfecb6bdcebf.jpg"/></spoiler>
 <spoiler title="Шаблон проекта">нам был, в общем-то, не нужен, т.к. задачи мы не храним в TFS, но, что поделать, придется шаблон  создать.
<img src="http://habrastorage.org/getpro/habr/post_images/adb/653/c02/adb653c025a8efa3bf04bf9bb2dcb425.jpg"/></spoiler>
 <spoiler title="Выбираем систему хранения исходников. Git, конечно."><img src="http://habrastorage.org/getpro/habr/post_images/850/cfa/ed6/850cfaed63d8b070379eed137a177634.jpg"/></spoiler>
Теперь у нас есть проект, к которому есть Git репозиторий.

<h4>Шаг шестой. Push на сервер.</h4>
Клонировав SVN репозиторий в Git, образовался тяжелый репозиторий. Просто так он не качается. Чтобы скачать, надо подкрутить конфигурацию.
<b>Gitconfig --globalhttp.postBuffer 524288000</b>
Ну, или руками вбить.
<spoiler title="Добавляем в список Remote нашего TFS. B Push."><img src="http://habrastorage.org/getpro/habr/post_images/f65/124/57a/f6512457a8949c007357fcd6acf96e86.jpg"/></spoiler>
Теперь наши исходники лежат в TFS.

<h4>Шаг седьмой. Вычистка репозитория.</h4>
Мы решили, что нам история нужна, но не ветки. Удалили все ветки и tags. Затем вынесли содержимое trunk на уровень выше, в корень.
<spoiler title="Веб морда к репозитарию исходников"><img src="http://habrastorage.org/getpro/habr/post_images/4a6/6d7/93d/4a66d793d80d528f44425a2b5b2f8738.jpg"/></spoiler>

<b>В итоге, на выходе: Git Server на Windows с нормальным менеджментом прав от TFS.</b>
Т.к я все делал через Git Extensios, а коллеги проверили из 3 других клиентов, то далее можно вообще забыть о том, что Git хоститься в TFS и работать с ним не вспоминая об этом.

<h4>Ложка Дегтя</h4>
Git поддерживается хорошо, но не все фишки Visual Studio и TFS, доступные для оригинального хранилища кода, поддерживаются в Git. Например CodeReview. Мы хотели вставить CoreReview перед Push, в центральный репозиторий. Пока этого нет, но всегда можно пропушить разработчиков в Visual Studio/TFS:  и <a href="http://visualstudio.uservoice.com/forums/121579-visual-studio">голосовать за добавление фичей</a>. Я лично  за CodeReview проголосовал.

P.S. статью можно править через <a href="https://github.com/SychevIgor/blog/tree/master/Migration_To_Git/svn">github</a>  
