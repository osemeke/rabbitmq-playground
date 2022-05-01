# RabbitMQ Playground
Testing pub/sub implementations on microservice events using RabbitMQ as a message broker

## Installation

### installers
    
    https://www.rabbitmq.com/install-windows.html
    https://www.erlang.org/downloads

### steps

    Open the command prompt & go to below location.
    C:\Program Files (x86)\RabbitMQ Server\rabbitmq_server-3.2.3\sbin

    Hit below command:
    rabbitmq-plugins `enable rabbitmq_management`

    Now, **restart** the RabbitMQ service
    Go to browser & hit this URL http://localhost:15672	 -- guest/guest

### management ui/cli docs

    www.rabbitmq.com/management.html
    www.rabbitmq.com/management-cli.html

## Docker

    https://hub.docker.com/_/rabbitmq

    `docker run -d -t -it --hostname my-rabbit --name rabbitmq-server -p 5672:5672 -p 15672:15672 -e RABBITMQ_DEFAULT_USER=ossy -e RABBITMQ_DEFAULT_PASS=pass1234 rabbitmq:3-management`

## Tutorials

    www.rabbitmq.com/tutorials/tutorial-one-dotnet.html
    www.rabbitmq.com/tutorials/tutorial-two-dotnet.html
    www.rabbitmq.com/tutorials/tutorial-three-dotnet.html
    www.rabbitmq.com/tutorials/tutorial-four-dotnet.html
    www.rabbitmq.com/tutorials/tutorial-five-dotnet.html

## Workflow

>   virtual host > user > exchange `routing_key` > `binding` queue > message

## Backround Worker Service


