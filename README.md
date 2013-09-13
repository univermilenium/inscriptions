Univer Extracciones Plantel->Online
=====================================

La solución consta de dos proyectos:

## extractions

Librería en C# que se encarga de consultar los datos al GES, realizar las validaciones pertinentes y exportarlos en formato CSV válido para la matriculación de alumnos en Moodle.

### Dependencias
La librería extracions hace uso del cliente SQL Firebird (http://www.firebirdsql.org/) para la conexión a GES, así como del conector de Microsoft para Access.

La librería consta de cinco clases que se agrupan en el espacio de nombre **univer.extractions**:

 * Extraction
 * Querys
 * QuerysTeachers
 * Tracking
 * User
 
### Extraction

Contiene los métodos para consulta a GES así como para la exportación al CSV.

### Querys

Contiene las consultas en SQL para obtener el registro de alumnos del plantel.

### QuerysTeachers

Contiene las consultas en SQL para obtener el registro de profesores del plantel.

### Tracking

Contiene los métodos para realizar el seguimiento de registros en la base de datos local de access, antes de crear el CSV, se verifica por registro si la inscripción ya fue validad anteriormente, en caso negativo, se agrega a la BD de seguimiento.

## inscriptions

Aplicación de consola que hace uso de la libreria **extractions**´. Punto de ejecución para la generación de inscripciones en formato CSV. Contiene los siguientes parámetros que se pueden cambiar según el plantel o  tipo de usuarios:

 * plantel:             Representa el string del nombre del plantel (SALUD, HIDALGO, RAYON, NEZA, IXTAPA).
 * FbConnectionstring:  Cadena de conexión a la BD de GES.
 * outputpath:          Directorio en dónde se generan los archivos CSV.
 * usertype:            Tipo de usuario a extraer (usuarios, profesores).
 * TrackingConnection:  Cadena de conexión a la base de datos de MS Access.

