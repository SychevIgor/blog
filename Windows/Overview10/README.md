﻿23 марта, стали доступны обучающие материалы по windows 10 на <a href="https://channel9.msdn.com/Series/Developers-Guide-to-Windows-10-Preview">Channel9</a>. В них много чего полезного, что облегчит жизнь разработчикам. Кратко опишу все эти изменения, собранные из 8-часового видеокурса. Лучше, конечно, читать и слушать в оригинале, но для тех, кому тяжело потратить 8 часов на англоязычный курс, данная статья может быть полезной.
<img src="https://raw.githubusercontent.com/SychevIgor/blog/master/Windows/Overview10/Start.png" alt="image"/>
<habracut text="Читам далее" />

<h4><b><a href="https://channel9.msdn.com/Series/Developers-Guide-to-Windows-10-Preview/02">Один раз скомпилировал, запустил везде</a></b></h4>
<b>До Windows 10</b>
Для тех, кто писал под windows phone и windows, всегда была проблема - есть как минимум 2 разных проекта, между которыми надо шарить код. Весь общий код выносился в третий проект. Неудобно до жути.
<b>С Windows 10</b>
Теперь, появился настоящий Universal App project. Т.е. проект теперь ровно один! Компилируем мы его один раз и получаем набор бинарных файлов, которые запустятся и на компьютере, и на телефоне под управлением windows 10.

<h5><b><a href="https://channel9.msdn.com/Series/Developers-Guide-to-Windows-10-Preview/04">Разные возможности устройств, но по-прежнему один бинарный файл </a></b></h5>
<b>До Windows 10</b> 
Еще со времен WPF/Silverlight разработчики использовали условную компиляцию (#if WPF  или #IF Silverlight) для кода, который, в целом, одинаков для платформ, но с определенными различиями. Код выглядел уродливо.
Равно такие же проблемы были с Silverlight для WP vs WinRT для PW8.1 и WinRT для Windows 8.1, т.к. API несколько отличался для всех 3 типов.

<b>В Windows 10</b> реализовано более элегантное, на мой взгляд, решение: 
Все классы и интерфейсы присутсвуют, и ошибки компиляции не будет.
Вызовы API, специфичных для конкретного типа устройства, таких как API аппаратной кнопки «Назад» или «Home», в Windows Phone работать будут, а вот для Windows-девайса, если ничего не менять, будет выпадать RunTime ошибка. 
Т.к. исполняемый файл у нас ОДИН, то взамен условной компиляции пришла метаинформация о реализованном API для платформы. 
<spoiler title="Выглядеть это будет так: "><img src="https://raw.githubusercontent.com/SychevIgor/blog/master/Windows/Overview10/ApiMetaTypePresent.png" alt="image"/></spoiler> 
<spoiler title="Хотя самой популярной должна стать проверка реализации типов, но сам API предоставляет на мой взгляд любые возможные провекри:"><img src="https://raw.githubusercontent.com/SychevIgor/blog/master/Windows/Overview10/ApiMeta.png" alt="image"/></spoiler>

<h5><b><a href="https://channel9.msdn.com/Series/Developers-Guide-to-Windows-10-Preview/05">Charm Panel умер, да здравствует SplitView</a></b></h5>
<b>До Windows 10</b>
На windows 8 появилась Charm Panel, которая была интересной идеей, но неподготовленному пользователю даже найти ее было непросто, а понять, что в ней можно искать функции приложения, так вообще непостижимо. В то же время, пользователи привыкли использовать на всех своих девайсах значки, похожие на выпадающие списки, в которых они привыкли искать настройки.
<b>С Windows 10</b>
Т.к. интерфейс Windows 10 был значительно переработан, то в итоге в появился SplitView, в который теперь рекомендовано переносить функционал,  находившийся ранее в Charm Panel. Charm Panel останется в Windows 10 в виде эмуляции, но ее лучше далее не использовать.
<spoiler title="SplitView понятнее и проще для пользователя."><img src="https://raw.githubusercontent.com/SychevIgor/blog/master/Windows/Overview10/SplitView.png" alt="image"/></spoiler>
Из этого следует, что снизится порог вхождения, увеличится visibility, а значит функционалом, заложенным ранее в Charm Panel, будут активнее пользоваться.

<h5><b>Relative Panel и Адаптация верстки к размеру экрана</b></h5>
На моей памяти, одним из факторов, замедлявшим портирование приложений с Windows Phone на Windows, а иногда просто отбивавшим всякое желание вообще этим заниматься, была проблема с разным размером экрана и ориентацией контента на экране. На телефоне человек держал телефон вертикально, и контент, как правило, скролился вниз, на компьютере (ширина экрана которого больше, чем высота) разумнее было контент скролить горизонтально.

<h5><b><a href="https://channel9.msdn.com/Series/Developers-Guide-to-Windows-10-Preview/08">Relative Panel</a></b></h5>
В Windows 10 добавился новый контейнер RelativePanel. Его суть заключается в том, что его дочерние элементы можно располагать друг относительно друга. 
<spoiler title="В примере показано, как, нарисовав один квадрат, второй мы ориентируем относительно первого. В данном случае - выше (Above). "><img src="https://raw.githubusercontent.com/SychevIgor/blog/master/Windows/Overview10/RelativePanelView.png" alt="image"/></spoiler>
<spoiler title="Код"><img src="https://raw.githubusercontent.com/SychevIgor/blog/master/Windows/Overview10/RelativePanelCode.png" alt="image"/></spoiler>
Таким образом, мы можем выбрать элемент-точку отсчета, и все остальные элементы располагать относительно него. Любые перемещения этого объекта, будут отражаться на позиционировании объектов, нахождение которых зависит от него. Лично по мне, это круто и снижает объем верстки, сложность падает, и жить становится легче. 
Причем это относительное позиционирование работает вместе с AdaptiveTrigger и написать вот такую трансформацию становится не таким уж время затратным.
<img src="https://raw.githubusercontent.com/SychevIgor/blog/master/Windows/Overview10/Adoptation.png" alt="image"/>

Как это сделать используя Blend рекомендую посмотреть в <a href="https://channel9.msdn.com/Series/Developers-Guide-to-Windows-10-Preview/09">видео</a>. 
Так же рекомендую посмотреть <a href="https://channel9.msdn.com/Series/Developers-Guide-to-Windows-10-Preview/11">доклад, что поменялось в части 3d трансформаций</a>.

<h5><b>Взаимодействие приложений между собой</b></h5>
Тут надо разделить на 2 части: новая фича <a href="https://channel9.msdn.com/Series/Developers-Guide-to-Windows-10-Preview/12">App Service</a> и <a href="https://channel9.msdn.com/Series/Developers-Guide-to-Windows-10-Preview/10">остальное взаимодействие</a>
<h5><b>Возвращаемое значение</b></h5>
<b>До Windows 10</b> приложение могло запустить другое приложение, но не могло получать ответ от него. Это все равно что написать функцию, у которой возвращаемое значение всегда было void. Это, конечно, все обходилось, но явно должно было быть проще. 

<b>С Windows 10,</b> приложение 1, которое вызвало другое приложение 2, может получить от него результат вызова. В этот ответ можно упаковать любые данные (главное, чтобы они были сериализуемые).

<h5><b>Указание вызываемого приложения</b></h5>
До Windows 10, когда мы из приложения 1 активировали приложение 2, мы не могли гарантировать, что будет открыто именно оно. Пользователь мог выбрать другое приложение... а оно могло не работать, могло передавать данные суперхаккерам и т.п.

<spoiler title="С Windows 10, мы можем явно указать, какое приложение будет открыто."><img src="https://raw.githubusercontent.com/SychevIgor/blog/master/Windows/Overview10/UriActivation.png" alt="image"/></spoiler>
На самом деле появилось еще несколько фичей, но их я рекомендую послушать в <a href="https://channel9.msdn.com/Series/Developers-Guide-to-Windows-10-Preview/10">оригинале</a>.

<h5><b><a href="https://channel9.msdn.com/Series/Developers-Guide-to-Windows-10-Preview/12">App Service</a></b></h5>
До Windows 10 приложения не могли предоставлять свой API без интерфейса другим приложениям, по сути. Были обходные пути в виде поднятия WCF сервиса и т.п., но это была скорее борьба с системой, а не ее использование.
В Windows 10 появилась такая фишка- App Service

Суть идеи: приложение может поднять внутри себя сервис и предоставлять его другим приложениям, установленным на этом же девайсе. Эта фича похожа по своей сути на backbground task, но ее можно использовать  не только приложением, в котором она находится, но и другими приложениями. Тем самым, платформа нам помогает предоставлять API, а не мешает. 

<img src="https://raw.githubusercontent.com/SychevIgor/blog/master/Windows/Overview10/AppServiceIdea.png" alt="image"/>

Примеры, где это можно использовать: у вас есть приложение платежной системы или сканер кодов. Вам не нужно для каждого приложения тащить все dll и писать свою реализацию. Можно написать один раз приложение, которое хорошо работает с распознаванием кодов, и всем остальным предоставляет этот функционал как сервис. 
<spoiler title="Клиент должен знать имя сервиса и PackageFamilyName для вызова и какие параметры передавать."><img src="https://raw.githubusercontent.com/SychevIgor/blog/master/Windows/Overview10/AppServiceClientSide.png" alt="image"/></spoiler> 

<b>Реализация на стороне сервиса такова: </b>
<spoiler title="Создаем BackgroundTask и на приходящее снаружи сообщение, регистрируем обработчик."><img src="https://raw.githubusercontent.com/SychevIgor/blog/master/Windows/Overview10/AppServiceServiceRegistration.png" alt="image"/></spoiler>

В обработчике мы получаем все параметры из словаря, и на основании них выполняем нашу логику, а затем, отправляем ответ вызвавшему нас клиенту. Возвращаем мы класс ValueSet, это такой набор ключ-значение.
<spoiler title="Код"><img src="https://raw.githubusercontent.com/SychevIgor/blog/master/Windows/Overview10/AppServiceServerRequest.png" alt="image"/></spoiler>

За более подробным описанием отправляю Вас в вебкаст, там и про жизненный цикл расскажут, и про то, как его отлаживать (для тех, кто проводил отладку background task, все знакомо).

<b><a href="https://channel9.msdn.com/Series/Developers-Guide-to-Windows-10-Preview/14">Web браузер и web приложения на html/js</a></b>

<img src="https://raw.githubusercontent.com/SychevIgor/blog/master/Windows/Overview10/WebApps.png" alt="image"/>

Уже несколько месяцев много говорится о новом браузере Spartan, и приложения на html/js будут использовать новый движок рендеринга этого браузера и получат кучу плюшек от этого. Более детально надо читать про сам браузер Spartan, поэтому расскажу о Hosted Web Apps. 

<b>Изменение в Hosted Web App</b> 
Лично я не назвал бы это приложением во многих случаях, т.к. если у вас уже есть веб сайт, то вы ссылку на него заворачиваете в ваше приложение, которое открывает внутри себя сайт в браузере. 
<spoiler title="Приложение, по сути, представляет из себя манифест, набор картинок для плиток и браузер.">
<img src="https://raw.githubusercontent.com/SychevIgor/blog/master/Windows/Overview10/HosterWebAppProjectExplorer.png" alt="image"/>
<img src="https://raw.githubusercontent.com/SychevIgor/blog/master/Windows/Overview10/HosterWebAppStartPage.png" alt="image"/>
</spoiler>

В приложении можно задать ограничения на то, какие URI разрешены, а какие нет. Тем самым вы ограничиваете пользователя от ухода с вашего сайта, через ваше же приложения серфить по просторам интернета.
<spoiler title="Пример задания ограничения на uri"><img src="https://raw.githubusercontent.com/SychevIgor/blog/master/Windows/Overview10/HosterWebAppUriLimits.png" alt="image"/></spoiler>
Что же изменилось? <b>Теперь нам не нужен WebView</b>, мы указываем стартовую страницу прямо в манифесте приложения.
<b>Вы можете интегрировать приложение с native API платформы</b>, той же самой Cortana, но это оптиционально. В JavaScript вашего сайта, вы проверяете, присутствует ли API windows в текущем контексте приложения или нет. Если присутствует, вы можете использовать это API
<img src="https://raw.githubusercontent.com/SychevIgor/blog/master/Windows/Overview10/HosterWebAppFeatureDetect.png" alt="image"/>

Приложение публикуется в Store, и пользователь может его найти, поставить, это увеличивает для Вас, как разработчиков, охват аудитории вашего сайта и создает новый источник пользователей при минимальных затратах времени.

<b>В статью не было включено следующее:</b>
<ul>
	<li>Я не стал описывать идеологию изменений в windows 10. Она предельно проста - единый windows, и это хорошо описано много раз до меня.</li>
	<li>Мое личное мнение: нам на просторах бывшего СССР не очень актуальны карты Bing (причины, я думаю, понятны всем).</li>
	<li>Также я не стал пересказывать, что стало легче работать с рукописным вводом, т.к. теперь есть контрол для этого. Это очень круто, но очень специфично.</li>
</ul>

P.S. Если Вы хотите помочь улучшить статью- можно предлагать ваши правки через <a href="https://github.com/SychevIgor/blog/tree/master/Windows/Overview10">github</a>