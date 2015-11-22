В azure есть 2 опции создание контейнеров: https://azure.microsoft.com/en-us/documentation/articles/virtual-machines-docker-vm-extension/ есть даже прямые ссылки с документации docker http://docs.docker.com/engine/installation/azure/
	Внутри WinSrv2016 preview https://msdn.microsoft.com/virtualization/windowscontainers/containers_welcome 
	В любом Linux дистрибутиве

Создать машинку можно из Visual Studio, из Портала или из CLI
	https://azure.microsoft.com/en-us/documentation/articles/virtual-machines-docker-with-xplat-cli/
Из VS можно создать при публикации приложения 
	https://azure.microsoft.com/en-us/documentation/articles/virtual-machines-docker-machine/ 
	http://video.ch9.ms/ch9/171d/01bf9b0c-2063-4283-9c91-aa46691e171d/VisualStudioDocker_high.mp4 Видео устаревшее, но суть понятная
	https://azure.microsoft.com/en-us/documentation/articles/vs-azure-tools-docker-hosting-web-apps-in-docker/
Портал https://azure.microsoft.com/en-us/documentation/articles/virtual-machines-docker-with-portal/ 
	
Если мы не на Linux или WinSrv2016 то мы можем поставить и на клиенсткий windows http://docs.docker.com/engine/installation/windows/ Но там есть нюансы в работе- в частности у нас поставится virtual box, а в нем уже linux.

ASPNET 50 поддерживает linux и docker соответсвенно http://docs.asp.net/en/latest/getting-started/installing-on-linux.html?highlight=container	

Как создать ключи http://docs.docker.com/registry/deploying/