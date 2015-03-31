Эта статья 3 из серии матбиблиотеки .net (<a href="http://habrahabr.ru/blogs/open_source/100379/">первая статья</a> и <a href="http://habrahabr.ru/blogs/open_source/101013/">вторая статья</a>). 
Эту статью я публикую не в блоге opensource, потому как почти все библиотеки не являются таковыми.

Рассмотрены будут следующие проекты:
<ul>
	<li><a href="http://www.dotnumerics.com/">DotNumerics</a> </li>
<li><a href="http://www.centerspace.net/"> NMath .NET</a> </li>
<li><a href="http://www.ffconsultancy.com/products/fsharp_for_numerics/index.html">F# for Numerics</a> </li>
<li><a href="http://www.mathworks.com/products/netbuilder/">MATLAB Builder NE</a></li>
<li><a href="http://www.extremeoptimization.com/">Extreme Optimization Numerical Libraries for .NET</a></li>
<li><a href="http://www.vni.com/products/imsl/cSharp/">IMSL Library</a></li>
</ul>

<habracut/>
<h4>Предисловие</h4>
Моя задача не изучить проекты от корки до корки. И даже не написать на них огромный проект, сравнивать производительность я тоже не планирую. Что бы сравнить производительность, нужно пару контор, которые софт пишет именно математический, каждый день и пару сотен разработчиков с тысячей сценариев. Простого способа сравнить нет. Я пишу небольшие обзоры отличительных черт и немного о наличии функционала в этих библиотеках, в качестве заметок для себя, т.к. в будущем мне будет необходимо использовать, некоторый функционал этих библиотек.

<b><h4>DotNumerics</h4></b>
Об этой библиотеке в первую очередь нужно сказать, что она является портом библиотеке на Fortran. Об этом можно догадаться по исходному коду, если кто видел фортран (по 80 символов на строке и нотации именования файлов и функций, так же абсолютный процедурный стиль).
На сайте проекта, указано о существовании некого <a href="http://www.dotnumerics.com/Services.aspx">загадочного сервиса</a> для конвертации кодов с fortran на C# находящегося где-то на сайте, но что бы получить доступ, нужно отписаться разработчикам.
Проект состоит из 3 уже традиционных частей:
<ul>
	<li><a href="http://www.dotnumerics.com/NumericalLibraries/LinearAlgebra/Default.aspx">Линейная алгебра</a>  (<a href="http://www.dotnumerics.com/NumericalLibraries/LinearAlgebra/CSBlas/Default.aspx">blas</a>, <a href="http://www.dotnumerics.com/NumericalLibraries/LinearAlgebra/CSLapack/Default.aspx">lapack</a>)</li>
	<li><a href="http://www.dotnumerics.com/NumericalLibraries/DifferentialEquations/Default.aspx">Дифференциальные Уравнения</a>(<a href="http://www.unige.ch/~hairer/software.html">RADAU5, DOPRI5</a>)</li>
	<li><a href="http://www.dotnumerics.com/NumericalLibraries/Optimization/Default.aspx">Оптимизация</a></li>
</ul>
На каждой  странице есть исходные коды на C# и ссылка на библиотеку, написанную на Fortran с которой был сделан порт.
Документация вся находится на сайте или в исходном коде. 
Есть отличные и вполне наглядные примеры.
<img src="http://s001.radikal.ru/i195/1008/3a/e0678b72f95a.jpg" alt="image"/>
<img src="http://s58.radikal.ru/i162/1008/79/f68d361012ab.jpg" alt="image"/>
<img src="http://i074.radikal.ru/1008/f0/e535b475f567.jpg" alt="image"/>

Если я правильно понял идеологию, то задача дать возможность людям, пишущим на fortran перейти на C#, с минимальными затратами. Т.е. названия процедур библиотеки знакые, только немного синтаксис языка изучить (по опыту обратного перехода с C# на fortran- это дело можно сделать ну за сутки) и в бой.

<b> Из плохого:</b>
Тестов нет, хотя библиотеки на fortran отлаживались десятилетиями и прямой порт вряд ли мог внести ошибки, Fortran ведь не очень богатый язык программирования в плане синтаксиса (он сделан был для математиков и их вычислений, а математики не очень то жалуют все эти программистские штучки. Они были бы счастливы, если бы их формулы от руки компьютеры понимали), по этому его легко конвертировать. 
От попытки разобраться в сорцах мало что хорошего выйдет. Вот такая милая диаграмма классов. Так, что: работает=> не трогайте!

<img src="http://s002.radikal.ru/i199/1008/2a/32d72bbfe6e3.jpg" alt="image"/>

Сайт проекта и сами сорц обновились последний раз в 2009 году, по этому для .net 4.0 сами займитесь переборкой проекта (благо это просто пару кару кликов, в связи с тем, что ни какие нововведения этот проект не использует, хватит версии .net и 1.1). Сайт проект частично тоже не доделан, но это общая беда всех проектов, которые я видел. 

В общем проект хороший, но ему бы чуть-чуть жизни вдохнуть.

<b><h4> NMath .NET</h4></b>
Еще один проект, со стандартным базовым функционалом,  но с огромными плюсами.
И так, проект коммерческий. Исходных кодов нет. Можно конечно покопаться рефлектором, но только в том случаи, если вы мастер деобфускации или знаток IL кода. Код не сильно обфурсцирован, всего то добавлено пару инструкций в il коды, что бы рефлектор выпадал с ошибкой при попытке сгенерировать C# или иной код.

Но честно говоря, в исходники мне лезть особо и не понадобилось, потому как есть хорошая документация (270 страниц - это вам не шутки.  Документация не из серии:  просто список классов, а как некоторый самоучитель.)
Отличительные черты проекта:
Существует прослойка, для запуска нативного кода <a href="http://software.intel.com/en-us/intel-mkl/">Intel MKL</a>

Проект умеет следующее: (если честно, стандартный джентельменский набор, только за счет MKL наверняка эта библиотека уделывает всех в производительности.)
<ul>
	<li>матрицы и вектора</li>
	<li>генераторы случайных чисел</li>
	<li>быстрое преобразование Фурье (FFT)</li>
	<li>численное интегрирование</li>
	<li>линейное программирование</li>
	<li>линейная регрессия</li>
	<li>оптимизация</li>
	<li>проверка гипотезы? не понял, что они имели ввиду</li>
	<li>дисперсионный анализ (ANOVA)</li>
	<li>распределения вероятностей</li>
	<li>кластерный анализ</li>
</ul>
Если честно, была бы библиотека бесплатной, не смотря на отсутствие кодов, использовал бы наверное именно ее. 

<b><h4>F# for Numerics</h4></b>
Честно говоря, совершенно не понятная для меня библиотека. Ее нельзя скачать даже в триал версии (не понятно почему). Цена ей 50 фунтов или 1000 за исходные коды. Но библиотека есть. Если кто знает F# и у кого есть 1000 фунтов, я очень буду рад узнать, что умеет эта библиотека.

<h4>MATLAB Builder NE</h4>
Очень серьезный софт... Как известно многие расчетные программы можно написать в маткаде или матлабе. Так вот, эта программа позволяет интегрировать программу расчетную в матлабе и наши традиционные приложения(Asp.Net, WCF, WinForms).
Фактически мощь этой библиотеки интеграции в мощности самого Matlab. Все, что можно написать в нем, можно с интегрировать с нашим софтом на .net. Я не силен в MatLab, и рекомендую заинтересованным разработчикам ознакомиться самим с этим интересным проектом.

<h4>Extreme Optimization Numerical Libraries for .NET</h4>
Наверное самая известная библиотека алгоритмом математических для .net
Библиотека платная, с закрытыми исходными кодами.

На главной странице проекта, есть очень серьезный список заказчиков, что внушает  доверие. Не могут ведь компании с мировым именем, типа Standard & Poor's , которые выставляют рейтинги кредитные странам там сильно ошибаться. А Армия США так точно серьезные парни, и они это библиотеку используют (интересно где именно правда.)


Заявленная функциональность на сайте следующая:
Прошу прощенье за мое некомпетентность в некоторых областях математики, но я перевел только то, что посчитал для себя 100% понятным и нужным в моих задачах.

<b>Математика:</b>

Базовая математика: комплексные числа, 'спец функции' такие как Gamma и Bessel функции, численное дифференцирование
Решение уравнений: решатели систем линейный и не линейных уравнений
Curve fitting: Linear and nonlinear curve fitting, cubic splines, polynomials, orthogonal polynomials.
Оптимизация: State of the art algorithms for finding the minimum or maximum of a function in one or more variables, linear programming.
Численное интегрирование.
Быстрое преобразование Фурье: 1D и 2D FFT использующее либо 100% управляемый код или более быстрый нативный (32 или 64 bit)
Библиотека для работы с длинными числами: BigInteger, BigRational, and BigFloat
framework для написания генетических алгоритмов: Write the code once and use it with any numerical type.

<b>Векторы и матрицы</b>

Real and complex vectors and matrices.
Работа с одинарной или двойной точностью(float или double).
Поддерживаются различные типы матриц: треугольные, разряженные, симметричные
Matrix factorizations: LU decomposition, QR decomposition, singular value decomposition, Cholesky decomposition, eigenvalue decomposition.
Производительность и переносимость: вычисления можно вести как на управляемом коде, так и вызовом нативного кода  (32 или 64 bit).

<b>Статистика</b>

Data manipulation: Sort and filter data, process missing values, remove outliers, etc. Supports .NET data binding.
Statistical Models: Simple, multiple, nonlinear, logistic, Poisson regression. Generalized Linear Models. One and two-way ANOVA.
Hypothesis Tests: 12 14 hypothesis tests, including the z-test, t-test, F-test, runs test, and more advanced tests, such as the Anderson-Darling test for normality, one and two-sample Kolmogorov-Smirnov test, and Levene's test for homogeneity of variances.
Multivariate Statistics: K-means cluster analysis, hierarchical cluster analysis, principal component analysis (PCA), multivariate probability distributions.
Статистические распределения: 29 различных распределений, такие как uniform, Poisson, normal, lognormal, Weibull and Gumbel (extreme value) .
Генераторы случайных чисел.

Есть целая куча примеров, по тому, как пользоваться этой библиотекой.
<img src="http://s60.radikal.ru/i168/1008/35/9665fe160b90.jpg" alt="image"/>

Мне лично вот захотелось посмотреть, на сам код вызова методов. Ничего страшного, главное знать что делать.
<img src="http://s002.radikal.ru/i199/1008/97/1bf69bc2bba3.jpg" alt="image"/>
<img src="http://s48.radikal.ru/i121/1008/21/519cf6e2963a.jpg" alt="image"/>
 
На мой взгляд у этой библиотеки 1 недостаток и 2 недостатка, которые может и преимущества.
 
<b>Недостаток</b>
Недостаток в том, что без тестов, прилагаемых к библиотеке, довольно тяжело ей доверять. Да, есть много примеров, заказчиков крутых, но человек существо недоверчивое (по крайней мере я не доверчив, после того, что я видел в исходниках других библиотек, о которых я рассказывал ранее)

<b>Недостаток-преимущество.</b>
1-Закрытые исходные коды. С одной стороны, плохо, что нет кодов, с другой стороны не знаешь внутренностей и оказываешься более спокоен, чем когда знаешь что там. Все-таки, не стоит смотреть на еду, то того когда она была приготовлена, она могла бегать, прыгать и мяукать.
2-библиотека платная. Если проект серьезный, то почему бы и не купить, ведь этот проект экономит кучу времени и сил. Хотя если вы студент и пишите курсовую или дипломную, то тут конечно на много тяжелее.

<h4>IMSL® C# Numerical Library for Microsoft® .NET Applications</h4>
Это библиотека, у которой есть множество версия для разных языков, но посмотреть я ее почему то так и не смог. На сайте, есть маленькая демка, и список, того, что умеет эта библиотека:
<ul>
	<li>Matrix Operations</li>
	<li>Linear Algebra</li>
	<li>Eigensystems</li>
	<li>Interpolation & Approximation</li>
	<li>Numerical Quadrature</li>
	<li>Differential Equations</li>
	<li>Nonlinear Equations</li>
	<li>Optimization</li>
	<li>Special Functions</li>
	<li>Finance & Bond Calculations</li>
	<li>Genetic Algorithm</li>
	<li>Basic Statistics</li>
	<li>Time Series & Forecasting</li>
	<li>Nonparametric Tests</li>
	<li>Correlation & Covariance</li>
	<li>Data Mining</li>
	<li>Regression</li>
	<li>Analysis of Variance</li>
	<li>Transforms</li>
	<li>Goodness of Fit</li>
	<li>Distribution Functions</li>
	<li>Random Number Generation</li>
	<li>Neural Networks</li>
</ul>
НО во-первых триал версия доступна, только после регистрации и отправки письма разработчикам. Я сделал это 2 раза и мне так и не пришел ответ, зато 1 раз пришло сообщение, что их почти не работает. Я повторил свой запрос через неделю, но результат ноль. Кстати, я так же пытался скачать версию для Java, но результат примерно тот-же. Единственную версию, что я таки смог добыть это версия для Python. Так, что возникает вопрос: это я такой неудачник, или ребята так работают хорошо? Если это я такой неудачник, то все понятно, а если нет, то может  у них так все работает, и может ну его их библиотеку!

<h4>Мысли в слух</h4>
Я посмотрел довольно много библиотек математических и с открытыми исходниками, и без них, платных и нет. Везде существует некоторая базовая часть функционала, особенно что касается статистики и численного интегрирования, матриц и векторов. 
Но в каждой есть своя особенность, такие как работа через  не управляемый код оптимизированных библиотек, таких как INTEL MKL, или код, портированный с fortran-а.

Что я еще для себя отметил. Вообще ученые не любят доверять свои работы, не понятным библиотекам. Ни кто не захочет подставить под удар свое доброе имя, а с закрытыми исходниками, ты не можешь полностью контролировать процесс счета.
С другой стороны, я столько видел исходных кодов, что иногда мне кажется, что лучше бы и не видел. Когда кода нет, то ты вроде как доверяешь программистам, его написавшим. Когда код есть, ты заглядываешь в него и начинаешь материться благим матом на них, так как постоянно видишь недописанный код, без пояснений, без документации, без тестов.

Основным отличием не opensource библиотек, от библиотек с открытыми исходниками для меня- это разрабатывается библиотека до сих пор или нет!
На Codeplex я видел массу интересных библиотек, но когда комиты идут раз в месяц и все 1 человеком, а последняя стабильная версия была 2 года назад, то как то опускаются руки. В платных, закрытых библиотеках, как то релизы более стабильные. Раз в полгода релиз с обновлениями есть. Наверняка такая ситуация с opensource не во всех сообществах, не во всех языках и не во всех направлениях, но я говорю за математические библиотеки на .net

<h4>P.S.</h4>
Для других языков программирования, таких как Java, C++, Fortran очень рекомендую сайт http://freemath.org/ . .Net там не представлен, зато много чего другого.

<h4>P.S.S.</h4>
Стать по Java обещаю опубликовать до конца недели. Думаю будет славный повод для Холивара, но я лишь выскажу свои мысли.