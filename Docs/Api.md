# FoodBnD Api

-[FoodBnd API](#foodbnd-api)
    -[Auth](#auth)
        -[Register](#register)
            -[Register Request](#register-request)
            -[Register Response](#register-response)
        -[Login](#login)
            -[Login Request](#login-request)
            -[Login Response](#login-response)



## Auth

### Register
```js
POST {{host}}/auth/register
```
### Register Request

```json
{
    "firstName" : "Yemisi",
    "lastName" : "Okafor",
    "email" : "yemisiokafor@gmail.com",
    "password" : "yemisiREBR@ND"
}
```

### Register Reponse
```json
{
    "id" : "d889c2d9a-eb3e-4075-95ff-b920b55aa104",
    "firstName" : "Yemisi",
    "lastName" : "Okafor",
    "email" : "yemisiokafor@gmail.com",
    "token" : "eyJhb..hbbQ"
}
```

### Login
```js
POST {{host}}/auth/login
```
### Login Request
```json
{
    "email" : "yemisiokafor@gmail.com",
    "password" : "yemisiREBR@ND"
}
```

### Login Response
```json
{
    "id" : "d889c2d9a-eb3e-4075-95ff-b920b55aa104",
    "firstName" : "Yemisi",
    "lastName" : "Okafor",
    "email" : "yemisiokafor@gmail.com",
    "token" : "eyJhb..hbbQ"
}
```

