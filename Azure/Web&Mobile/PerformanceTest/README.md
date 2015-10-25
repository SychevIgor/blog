Долго время Azure и Visual Studio Online были по сути разделены, но мир меняется. И наконец-то, мы добавили самую полезную для веб разработчиков фичу VSO - Load Testing прямо на Azure Portal в preview режима. 
Она сейчас доступна в режиме <a href="https://azure.microsoft.com/en-us/services/preview/ ">preview</a>.

<img src="https://habrastorage.org/files/9fb/b08/d65/9fbb08d65d8241deb25009290bbb636f.png"/>
<cut>
<h5><b>Что нам для этого нужно: </b></h5>
<ul>
	<li>vso аккаунт</li>
	<li>azure подписки</li>
	<li>какое-нибудь веб приложение, развернутое в ней.</li>
</ul>
<h5><b>Ну а дальше и ребенок справится.</b></h5>
<spoiler title="Выбираем веб приложение"><img src="https://habrastorage.org/files/f46/7aa/e06/f467aae064f1402ba165e1e28581064f.png"/></spoiler>
<spoiler title="Выбираем Tools -> Performance Test"><img src="https://habrastorage.org/files/650/812/67d/65081267de4a48348d47b72b0c993535.png"/> </spoiler>
<spoiler title="Подключаем VSO аккаунт к этому сайту"><img src="https://habrastorage.org/files/65f/ded/992/65fded992bbe47f2baea59828ef35494.png"/> </spoiler>
<spoiler title="Затем выбираем какой URL мы будем тестировать, время теста, количество виртуальных пользователей, и регион из которого мы будем тестировать."><img src="https://habrastorage.org/files/b9e/b76/bef/b9eb76befccd4d51bcf527a2c32d5b86.png"/> </spoiler>
<b>Нажимаем кнопку Run и ждем окончания теста.
</b><spoiler title="Количество запусков теста - на наше усмотрение. Сам тест может быть в 3 штатных состояниях (в процессе тестирования, окончен, ожидание ресурсов.)"><img src="https://habrastorage.org/files/411/07b/929/41107b929f124efd841bb18bf3d1653a.png"/></spoiler>
<spoiler title="Каждый запуск теста можно увидеть и на блейде веб приложения и на вкладке Performance Test. "><img src="https://habrastorage.org/files/d9d/08e/8a6/d9d08e8a61ef45e39328b3585b105338.png"/></spoiler>
<spoiler title="Но на блейде Performance Test- можно посмотреть параметры тестирования."> <img src="https://habrastorage.org/files/9fb/b08/d65/9fbb08d65d8241deb25009290bbb636f.png"/> </spoiler>

Любой из запусков можно запустить еще раз, нажав кнопку re-run. Т.е. можно собрать множество разных тестов, в зависимости от необходимого профиля нагрузки на разные страницы сайта.

Кому интересно узнать больше- рекомендую попробовать самому ну или прочитать <a href="https://azure.microsoft.com/en-us/documentation/articles/app-service-web-app-performance-test/">документацию</a>.

<h5><b>Советы:</b></h5>
Если вы хотите протестировать пре-продакшен версию вашего приложения, развернутую на дополнительном deployment slot- не забывайте, что эти слоты и ваша продуктивная версия сайта, используют одно и тоже железо. 

Биллинг- пока есть лишь информация, что на время public preview- у вас есть определенный набор минут, которые вы можете использовать. На момент написания статьи, я не смог разобраться почему я потратив несколько тысяч минут, не вижу этого в моем VSO аккаунте. Но т.к. это тестовая версия- я не удивлен.