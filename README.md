# RestApiWeb

API con autenticacion basada en Tokens
para empezar a ejecutar la aplicacion, es necesario hacer la migracion de las bases de datos SQL con los siguientes comandos:
Add-Migration "Mensaje"
Update-Database

Esto creara dos bases de datos, una de usuario, donde tendremos que insertar el usuario y contraseña con el que nos loguearemos y otra con los datos de los clientes, que nos devolvera cuando llamemos a la API
Tabla User: 
- Token: Este campo sera null y lo almacenara automaticamente la aplicacion cuando se genere un token valido.
- UserValid: Este campo valida si el usuario esta autorizado a utilizar la API, si es False no podra autenticarse y recibira un codigo 401.
- State: Esta campo es para comprobar si el usuario sigue activo o se le ha dado de baja, con este campo controlaremos los borrados logicos.

Tabla Customer:
- Date: Con este campo controlaremos la antiguedad del usuario desde que se registro en nuestra aplicacion.
- State: Igual que en la tabla user, usaremos este campo para el borrado logico, aunque aun no esta implementado en los Getters

Una vez rellenados los datos, podremos empezar a consumir la API, para ello podemos usar una aplicacion como Postman y empezar a enviar y recibir datos.
- Solicitar token con POST https://localhost:44395/api/Access
le pasaremos un User y Passw
Ej.: {
  "UserName":"Admin",
  "Password":"abc123"
}

- Pasandole el Token recibido anteriormente, obtenemos todos los clientes con: https://localhost:44395/api/customers/GetAllCustomers
- Si queremos un usuario especifico, le pasaremos: https://localhost:44395/api/customers/GetCustomerData/{id}

Actualmente, estos metodos llaman a la cache, es necesario tener corriendo un server Redis para que funcione, para almacenar los datos en cache, tenemos que insertar un Cliente con la siguiente llamada:
- POST: https://localhost:44395/api/Customers/CreateCustomer
{
  "Surname":"Ruíz",
  "Name":"Juan",
  "Age":"34",
  "Email":"juan.ruiz@gmail.com",
  "PostalCode":"45800"
}
