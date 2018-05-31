# 前提
该项目使用版本信息如下： 
.Net Core版本：2.0  
Ocelot版本：7.0.4


# 项目说明
该项目用于Ocelot学习。共有4个项目：ApiGateway、ProductService、UserService、ClientTest  

# 项目介绍
* ApiGateway：微服务网关
* ProductService：微服务，返回Product信息
* UserService：微服务，返回User信息
* ClientTest: 客户端，访问网关获取Product和User信息

# 运行顺序
1. UserService
启动后可以通过访问[http://localhost:8001/api/user]验证服务是否启动成功

2. ProductService  
启动后可以通过访问[http://localhost:8002/api/product]验证服务是否启动成功

3. ApiGateway
启动后可以通过访问[http://localhost:5000/api/product, http://localhost:5000/api/user]验证网关服务是否启动成功

4. ClientTest
启动后可以通过访问[http://localhost:8003/api/values]验证微服务是否可以通信

# Q&A
如果启动时有端口冲突，请修改启动端口和ApiGateway项目中Ocelot的配置信息