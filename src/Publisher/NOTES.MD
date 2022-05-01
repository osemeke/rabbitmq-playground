
## INSTALLERS
https://www.rabbitmq.com/install-windows.html
https://www.erlang.org/downloads


Open the command prompt & go to below location.
C:\Program Files (x86)\RabbitMQ Server\rabbitmq_server-3.2.3\sbin

Hit below command:
rabbitmq-plugins enable rabbitmq_management

Now, restart the RabbitMQ service
Go to browser & hit this URL http://localhost:15672	 -- guest/guest


www.rabbitmq.com/management.html
www.rabbitmq.com/management-cli.html

https://hub.docker.com/_/rabbitmq

$ docker run -d --hostname my-rabbit --name some-rabbit rabbitmq:3

docker run -d --hostname my-rabbit --name some-rabbit -e RABBITMQ_DEFAULT_USER=user -e RABBITMQ_DEFAULT_PASS=password rabbitmq:3-management

docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.9-management

### Working
docker run -d -t -it --hostname my-rabbit --name rabbitmq-server -p 5672:5672 -p 15672:15672 -e RABBITMQ_DEFAULT_USER=ossy -e RABBITMQ_DEFAULT_PASS=pass1234 rabbitmq:3-management

rabbitmq-plugins enable rabbitmq_management



### Links
https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html
www.rabbitmq.com/tutorials/tutorial-two-dotnet.html
www.rabbitmq.com/tutorials/tutorial-three-dotnet.html
www.rabbitmq.com/tutorials/tutorial-four-dotnet.html
www.rabbitmq.com/tutorials/tutorial-five-dotnet.html

> docker run -it --rm --name mymq -p 5672:5672 -p 15672:15672 rabbitmq:3-management



