# UNO! Legends #

----------
## Sobre mí ##
Soy Guia Leandro y la verdad este trabajo me pareció un desafío, pero uno que fué divertido y con el cual aprendí varias cosas que muy probablemente me ayuden en proyectos futuros. Realmente quería agregar MUCHAS mas funcionalidades al proyecto (como la capacidad de crear más jugadores (npcs) que a medida que ganen partidas suban de nivel y con ello aumenten su suerte para que les toquen más cartas especiales, entre otras cosas) pero lamentablemente me quedé sin tiempo.Probablemente siga mejorándolo con el tiempo porque me pareció un proyecto "copado" que vale la pena terminar de redondear.

##Resumen##
Esta aplicacion emula a 2 jugadores **(bot vs bot)** en una partida del famoso juego de cartas *"UNO"*. Al abrir la aplicacion se va a encontrar con el *menú principal* dónde podrá iniciar una nueva partida **(pueden ser varias en simultaneo)**, ingresar al **historial de partidas recientes** y un boton para salir de la aplicación.

----------
**Nueva partida:** Al pulsar esta opcion verá cómo se abre una nueva ventana e instantáneamente cómo los 2 jugadores comienzan a jugar (de forma autónoma). En esta ventana también podrá ver información adicional, así cómo las partidas ganadas de los jugadores, sus nombres y qué cartas tienen en su mano. Por otra parte, en el sector inferior se encuentra la ***Barra de acciones*** dópnde podrá ver los movimientos de cada jugador.

**Terminar juego:** Con este botón va a ser capaz de interrumpir la partida de forma prematura.

----------
**Al terminarse la partida:** Cuando esto suceda usted verá una nueva ventana con las estadísticas de la partida jugada (así como su cantidad de jugadores, ganador, turnos, etc), y tendrá la posibilidad (*opcional*) de exportar los datos de esa partida en formato de archivo .jSon

# Diagrama de clases #
![](https://i.imgur.com/8DnR2yE.png)

# Justificaciones técnicas #
**SQL:** Utilizado para guardar y cargar datos para el correcto funcionamiento de la aplicacion. Por ejemplo, haciendo uso de SQL y SQL Sever M.E almaceno y utilizo datos tales como los **jugadores** y **el historial de partidas**.
 
**Excepciones:** Utilizadas en la **clase BBDD** para manejar posibles errores en la base de datos.


**UTesting:** En la solucion se encuentra el proyecto llamado **UnitTests** dónde se encuentran  las distintas pruebas para las clases principales del programa.


**Generics:** Utilizado en la **clase archivos** dónde hay un método que hace uso de este tema.


**Serializacion:** En la **clase archivos** se encuentra un método de serializacion combinado con **Generics.**
Haciendolo de esta manera puedo serializar lo que sea sin necesidad de crear un nuevo método. En el proyecto se utiliza para exportar los datos de la partida en formato jSon.

**Interfaces:** Implementé 2 de ellas. La primera es **IJuegoDeCartas** aplicada en la clase **"UNO"**, esta interfaz funcionaría como referencia para cualquier otro juego de cartas, ya que todos ellos compartirían los elementos especificados en dicha interfaz. Lo mismo sucedería con **IBaseDeDatosParaJuegoDeCartas** utilizada en la **clase BBDD**

**Delegados:** Ubicados en un codefile llamado **Delegados.cs**, la mayoría de ellos creados para ser utilizados con **eventos** *(Como por ejemplo **DelegadoNotificacion** o **DelegadoGameOver**). Sin embargo, se hace uso de un delegado *tal cual* en la clase **Jugador** llamado **OnTomaCarta** que utiliza el delegado definido como **obtenerCarta**

**Task:** La programación multihilo fué utilizada en el formulario **FrmUNO**, dónde se crea una tarea que ejecutará el método **Jugar** de la instancia de la clase **UNO** (la cual, inicia un *game-loop* infinito)

**Eventos:** Muy utilizado en la aplicación, se puede ver su uso, *sobre todo*, en la clase **UNO**. Allí se pueden encontrar eventos como **OnNotificacion** (al cual estoy suscrito desde el formulario **FrmUNO** para que haga cambios en el texto de un textBox) entre varios otros.