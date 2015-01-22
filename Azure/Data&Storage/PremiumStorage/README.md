В октябре Microsoft анонсировал появление <b>Azure Premium Storage</b> на 2-х своих мероприятиях <a href="http://news.microsoft.com/2014/10/20/CloudDayPR/">CloudDay</a> и <a href="http://europe.msteched.com/">TechEdEurope </a>, а не так давно он стал доступен в статусе <a href="http://azure.microsoft.com/en-us/services/preview/">preview </a>.

Фактически <b>Premium Storage – это тот же Storage, что был раньше, только на SSD и только для дисков виртуальных машин</b> (не для Blob, Table, Queue). При этом на данный момент premiumStorage доступен только для машин <a href="http://msdn.microsoft.com/en-us/library/azure/dn197896.aspx">DS серии</a>. <b>Максимально можно использовать до 32ТБ на виртуальную машину, с суммарным I/O до 50 000 IOPS.</b>

<img src="http://habrastorage.org/files/dc3/99a/b58/dc399ab584b742689fa597913b3ab578.png" alt="image"/>

Анонсировали этот сервис вместе с новым типом виртуальных машин для AzureG-Series, который будет иметь самые современные процессоры (Intel® Xeon® processorE5 v3 family.), а также локальные твердотельные диски (SSD). Т.е. совместно нам предлагают конфигурации, все более мощные, которые раньше нельзя было получить. 
<habracut text="Чтобы понять, почему это круто/нужно, необходимо вспомнить ситуацию, сложившуюся несколько лет назад." />

<h5><b>Azure изначальный</b></h5>
В 2010 году, когда Azure только начиналось, был доступен для выбора достаточно скромный набор сервисов: Storage (Blob, Table, Queue), SQLAzure, WebRole, WorkerRole.

На просьбы предоставить виртуальные машины, как в Amazon, ответ был в стиле: <b>“Облако супермасштабируемо, вы снимаете с себя головную боль за железо, ОС и в такой парадигме виртуальные машины не нужны.”</b>
После чего шел вопрос/проблема: <b>“Так, это нам все же переписать нужно будет, а время разработки стоит денег, причем больших”.</b>
На это ответ был : <b>“Зато потом, вы сэкономите на эксплуатационных расходах, сократите непрофильный обслуживающий персонал, получите возможность быстрее разрабатывать ваши решения и запускать их в эксплуатацию.”</b>
Звучало все это хорошо и красиво, да и идея переписать немного свои приложения, сделав их более масштабируемыми, была заманчива, только это было не всегда возможно, да еще и дорого. 

И тогда WebRole, WorkerRole можно было только на .net писать,  и есть у тебя Java какая-нибудь, то было совсем неинтересно. Т.е. в лучше случае можно было получить частичное решение, часть локально, часть в Azure.
Это потом уже появилась возможность использовать не .net платформы, появились виртуальные машины (в том числе и не windows) и так далее….

С появлением виртуальных машин стало возможно без сильного переписывания перенести много большую часть приложений в azure, но был нюанс: сильно прожорливым приложениям для нормальной работы этих виртуалок не хватало, не хватало производительности HDD и этим приложениям, следовательно, дорога в Azure была заказана. Именно эту проблему и решает PremiumStorage, которое на одном узле может выдать огромные IOPs + вычислительные мощности за счет процессоров на виртуалках G-серии.

<h4><b>Premium Storage</b></h4>
Сейчас диски для виртуальных машин – это blob, хранящиеся на HDD-носителях. Если нужен больший объем быстрых дисков, то тут подключаем Premium Storage и мы можем использовать до 32ТБ SSD на виртуальную машину. 32ТБ – это огромный объем, который еще надо постараться утилизировать. Правда, сейчас это доступно только для GS-серии. Но в итоге думаю и для G серии тоже будет доступно.

<spoiler title="Информация о виртуальных машинах G серии">
Про использование PremiumStorage для машин серии G пока ничего не сказано, но думаю, для них оно тоже будет доступно, просто G-серия еще сама не вышла, а только анонсирована.
Виртуальные машины G-серии предлагают от 406ГБ до 6500Гб SSD (<a href="http://azure.microsoft.com/blog/2014/10/20/azures-getting-bigger-faster-and-more-open/">таблица</a>) дискового пространства. 
<table border="1" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td valign="top" width="139">
<p style="text-align: center;"><b><i>VM Size</i></b></p>
</td>
<td valign="top" width="113">
<p style="text-align: center;"><b>Cores</b></p>
</td>
<td valign="top" width="198">
<p style="text-align: center;"><b>RAM (in GB)</b></p>
</td>
<td valign="top" width="270">
<p style="text-align: center;"><b>Local SSD Storage (in GB)</b></p>
</td>
</tr>
<tr>
<td valign="top" width="139">
<p style="text-align: center;"><i>Standard_G1</i></p>
</td>
<td valign="top" width="113">
<p style="text-align: center;">2</p>
</td>
<td valign="top" width="198">
<p style="text-align: center;">28</p>
</td>
<td valign="top" width="270">
<p style="text-align: center;">406</p>
</td>
</tr>
<tr>
<td valign="top" width="139">
<p style="text-align: center;"><i>Standard_G2</i></p>
</td>
<td valign="top" width="113">
<p style="text-align: center;">4</p>
</td>
<td valign="top" width="198">
<p style="text-align: center;">56</p>
</td>
<td valign="top" width="270">
<p style="text-align: center;">812</p>
</td>
</tr>
<tr>
<td valign="top" width="139">
<p style="text-align: center;"><i>Standard_G3</i></p>
</td>
<td valign="top" width="113">
<p style="text-align: center;">8</p>
</td>
<td valign="top" width="198">
<p style="text-align: center;">112</p>
</td>
<td valign="top" width="270">
<p style="text-align: center;">1,630</p>
</td>
</tr>
<tr>
<td valign="top" width="139">
<p style="text-align: center;"><i>Standard_G4</i></p>
</td>
<td valign="top" width="113">
<p style="text-align: center;">16</p>
</td>
<td valign="top" width="198">
<p style="text-align: center;">224</p>
</td>
<td valign="top" width="270">
<p style="text-align: center;">3,250</p>
</td>
</tr>
<tr>
<td valign="top" width="139">
<p style="text-align: center;"><i>Standard_G5</i></p>
</td>
<td valign="top" width="113">
<p style="text-align: center;">32</p>
</td>
<td valign="top" width="198">
<p style="text-align: center;">448</p>
</td>
<td valign="top" width="270">
<p style="text-align: center;">6,500</p>
</td>
</tr>
</tbody>
</table>
</spoiler>

Когда вы запрашиваете диск определенного объема, место под него выделяется на одной из возможных дисковых конфигураций перечисленных ниже:
<img src="http://habrastorage.org/files/8a2/bd6/aa2/8a2bd6aa2ae14bdaa52ca248165f3aef.png" alt="image"/>
<ul>
<li><a href="http://azure.microsoft.com/en-us/pricing/details/storage/">Цены</a>– это цены за сами диски, тарификация по часам.</li>
<li>Если вы делали snapshot (readonly-копия), то это отдельно. </li>
<li>Если вы хотите вытащить диск/данные из Azure– это, как всегда за исходящий трафик, платится <a href="http://azure.microsoft.com/ru-ru/pricing/details/data-transfers/">отдельно</a>. </li>
</ul>

<h5><b>Подсчет I/O</b></h5>
Подсчет объема трафика I/O оказывается нетривиальной задачей. Квант передаваемых данных равен 256кб, т.е. если вы читаете/пишете кусок данных меньшего размера, то при передаче он учитывается с округлением в “потолок” с точностью до 256кб. Т.е. 1100кб это 5 квантов I/O, т.к. 1024(4*256) <1100< 1280 (5*256)

<h5><b>Важные моменты</b></h5>
<ul>
	<li>На данный момент сервис доступен в 3 регионах: WestUS, EastUS 2, and WestEurope.</li>
	<li>Premium Storage локально распределенный (locally redundant -LRS).</li>
	<li>PremiumStorage могут быть использованы вместе с StandardStorage (HDDдисками).</li>
</ul>

<b>Вывод: конфигурации становятся все более мощными, быстрыми -> технологических ограничений, чтобы не переходить в Azure остается меньше. Финансовые и политические моменты в статье не обсуждаются...</b>

<h5><b>Ссылки</b>:</h5>
<ul>
	<li><a href="https://weblogs.asp.net/scottgu/azure-premium-storage-remoteapp-sql-database-update-live-media-streaming-search-and-more">Анонс от Гаттри</a></li>
	<li><a href="http://azure.microsoft.com/blog/2014/12/11/introducing-premium-storage-high-performance-storage-for-azure-virtual-machine-workloads/">Кратко про новые типы виртуалок и новые primiunStorage</a></li>
	<li><a href="http://azure.microsoft.com/en-us/documentation/articles/storage-premium-storage-preview-portal/">Описание</a></li>
	<li><a href="http://msdn.microsoft.com/en-us/library/azure/dn727290.aspx">Про распределенность хранилища</a></li>
	<li><a href="http://azure.microsoft.com/en-us/pricing/details/storage/">Цены</a></li>
</ul>

Статья доступна на github https://github.com/SychevIgor/blog/tree/master/Azure/Data%26Storage/PremiumStorage
