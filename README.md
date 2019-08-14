# MTR-SYSTwo
Proyecto Evaluación: Web Developer Application Test

# OBJETIVOS
* Explorar conocimientos medios-avanzados en cuanto al desarrollo de software.
* Desarrollo de una aplicación web, basado en tecnologías .Net y algún framework de javascript.

# PUNTOS A EVALUAR (En orden de prioridad)
1. Correcto Funcionamiento.
2. Modelado del Dominio.
3. Correcta separación de responsabilidades.
4. Servicio REST.
5. Pruebas unitarias.
6. Extras (ningún orden particular):
	* Persistencia de datos
	* Separación en capas (distintos proyectos)
	* Inyección de dependencias
	* UI/UX
	* Estándares de codificación de C#

# CONSIDERACIONES
* Sera un único desarrollo utilizando tecnologías .net y algún framework de javascript.
* No incluir la carpeta Packages , BIN ni OBJ.
* El entregable debe ser Archivo zip que contenga la solución de Visual Studio compartida a través de Google Drive, One Drive o similar.
* La misma debe compilar luego de descargar las dependencias necesarias.

# DESARROLLO (EsRe)
* Un modelo que represente una computadora con los siguientes atributos:
	- Procesador.
	- Memoria.
	- Disco (pueden ser Hard Drive o Solid State , se sugiere utilizar herencia)
* Al ejecutar la aplicación se deben instanciar 3 computadoras con todos sus atributos, simulando las computadoras que existen en una empresa de desarrollo de software.
* Una página web que muestre en una grilla con:
	- Una lista con las memorias que tengan capacidad superior a 8GB.
	- Debe tener al menos 5 columnas, mostrando datos de la memoria en si misma y de la computadora a la que pertenece.
* Un servicio rest que por GET retorne en formato json, los datos que se muestran en la grilla.
* Test unitarios que validen la lógica que consumen la grilla y el servicio rest.
---

# Estructura del Repositorio
A continuación se detallan los distintos archivos y carpetas que componen el repositorio.

* **LICENSE**  
    Licencia de Software Libre GNU GPL v3.
* **README**  
    Este documento.
* **Documentos**  
    Carpeta con archivos del proyecto: Notas y Modelo del Dominio.
* **Proyecto**  
    Carpeta donde se implementa la solución del proyecto.
