
docker-compose down
docker-compose build

#docker-compose up


#列出所有windcatcher用户名的docker镜像
docker image ls windcatcher/*

# #删除所有windcatcher用户名的docker镜像
# docker rmi $(docker images windcatcher/* -q)

#tag镜像user_service并推送，用户名为windcatcher，tag为v1
docker tag user_service windcatcher/user_service:v1
docker push windcatcher/user_service:v1

# tag镜像product_service并推送，用户名为windcatcher，tag为v1
docker tag product_service windcatcher/product_service:v1
docker push windcatcher/product_service:v1

#tag镜像identity_service并推送，用户名为windcatcher，tag为v1
docker tag identity_service windcatcher/identity_service:v1
docker push windcatcher/identity_service:v1

#tag镜像ocelotgateway并推送，用户名为windcatcher，tag为v1
docker tag ocelotgateway windcatcher/ocelotgateway:v1
docker push windcatcher/ocelotgateway:v1

#tag镜像simpleclient并推送，用户名为windcatcher，tag为v1
docker tag simpleclient windcatcher/simpleclient:v1
docker push windcatcher/simpleclient:v1