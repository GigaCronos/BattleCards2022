# Batalla de Cartas 2022
## Introducción
Este informe tiene como objetivo plasmar parte de la información que se debe conocer acerca de nuestro Juego de Cartas. A continuación explicaremos las cuestiones más importantes del mismo, su estructura, métodos y clases significativas, entre otros puntos relevantes. 

## ¿En qué consiste el juego y cuáles son sus reglas?
### Vision general
El juego es basicamente un juego de ataque. Inicialmente cuenta con 18 cartas (se pueden añadir más cartas), que pueden ser utilizadas por dos jugadores (human players), dos jugadores virtuales (IA), o un jugador y la IA. Cada carta posee salud, mana, daño, armadura y velocidad. Los jugadores inicialmente tienen la posibilidad de elegir 3 cartas, pero tienen el poder de variar y elegir de 1 a 6 cartas. Cada jugador debe defender sus cartas; para esto, deberá utlizar el ataque hacia el otro jugador, con el objetivo de disminuir su capacidad de vida y de este modo eliminar las cartas que le pertenecen a su rival. Un jugador gana, cuando su adversario tiene en 0 la vida de todas sus cartas, puede existir la posibilidad de un empate (aunque es muy remota).

### Temática
El juego tiene una temática parecida a la del Dota2, la Stat armadura se encarga de mitigar el daño físico, las cartas no poseen defensa mágica, por tanto estos son los ataques mas poderosos, se sugiere que se mantenga apegado a esta temática a la hora de crear futuras cartas(ánimo, todavía quedan unos 103 héroes por crear). El mana es necesario para usar poderes mágicos y de curación.

### Mecánicas
-Para jugar elija en el menu Opciones la cantidad de cartas que llevará cada jugador(3 por defecto), también podrá cambiar el color de fondo de la consola y el de las letras.
- Por favor memorice lo que hace cada carta antes de jugar(a la hora de seleccionarlas en la parte CardInfo), usar un poder mágico sin tener el mana necesario para ello incurrirá en la pérdida de su turno en vano. 
- El daño físico(acción Attack) fluctúa entre una rango determinado por ejempo si su daño es 45-50 significa que a la hora de atacar se escogerá un valor random entre 45 y 50 incluidos.
- Cuando una carta es atacada físicamente tiene una probabilidad de un 25% de evadir el ataque, esta es una stat- (Evasion) que el jugador no  puede ver, pero se puede modificar a través de efectos de cartas.
- El daño físico es mitigado por la armadura, por otro lado el mágico no, por tanto los ataques mágicos son más poderosos. 
- La Stat Speed indica el tiempo que demora cada carta para volver a realizar alguna acción, no se confunda, mientras menos Speed mejor!
- Al terminar cada turno aumentara el daño de cada carta asi como su mana y su vida(simulando la regeneración y el aumento de nivel).

### Ingeniería de Software
De esta parte del juego se encarga la clase Board, con su interfaz IBoard, esta es la que realiza las acciones como atacar, curar o realizar ataques mágicos en dependencia de lo especificado en el scrpit de la carta. 

Contamos con una estructura de datos de nuestra creacion llamada `OrderedList<TKey,TValue>` que se encarga de mantener un conjunto de elementos todo el tiempo ordenados por unas llaves, soporta operaciones como insercción, borrado, asi como acceder a elementos intermedios. Es genérica, implementa IEnumerable y recibe un delegado `Comparission<TKey>` como argumento.

Tenemos una clase Catalog que implementa ICatalog, encargada de manejar todo lo correspondiente al almacenamiento de cartas, a partir de el se puede acceder a la Info de una carta dado su nombre asi como al Obejeto de tipo IMonsterCard que la representa, soporta operaciones como añadir cartas nuevas y preguntar si una carta es válida, tiene un metodo de recorrido `GetCards()`,  no confundir con `GetCard()` usado para obtener una carta dado su nombre.Se prevee en actualizaciones futuras un metodo de filtrado.

La clase Board es el Motor del juego, quien lleva las cuentas de quien gana y que cartas quedan vivas, también se encarga de calcular el `Log` mensaje mostrado acerca de lo ocurrido en ese turno. Aquí no pudimos lograr seguir con el principio de responsabilidad unica porque consideramos que para ello seria necesario MultiThreading.


## Jugadores
### Jugador Virtual
El jugador virtual sigue una estrategia muy sencilla que consiste en atacar siempre a la misma carta hasta que muera, aunque en pocas ocasiones decidirá usar alguna de las otras acciones disponibles que tenga la carta que controla. No recomendamos que ponga a jugar a dos IAs entre sí debido a que el juego entre ellas podria prolongarse y no hay manera de detenerlas ya que una partida termina solo cuando alguien se rinde o pierde.

### Ingeniería de Software
Para el manejo de jugadores se creo una interfaz IPlayerInterface que es la Interfaz Gráfica usa para comunicarse con los jugadores hay dos clases que implementan esta interfaz, HumanInterface e IAInterface. Nuestro jugador virtual llamado `Greedy01` implementa la interfaz `IPlayer` que es la que deberían implementar todos los jugadores virtuales en un futuro.


## Compilador
### Sintaxis
#### Asignación y Declaración de Funciones
Cada script consiste en una declaración de varias funciones y asignación de Variables. El único tipo que soporta el lenguaje es *Int32* por tanto no es necesario a la hora de declarar una variable decir el tipo. Una declaracion de variable *`MiVariable`* e igualarla a 5 sería algo tan simple como:
```cs
MiVariable=5;
```
A la hora de declarar una función, de igual manera se seguirá el formato normal de C++ lo que sin declarar en tipo(porque es Int32). El valor de retorno se especifica asignando a una variable reservada *`return`* el valor de retorno deseado,*`return`* es una variable que se declara automáticamente en el contexto de una función, y no terminará al hacer uso de esta. Una declaración de una funcion que devuelva el valor 7 sería la siguiente:
```cs
MiFuncion(){
    return=7;
}
```
Para usar parámetros se enlistarán solo el nombre de estos dentro de los parentésis de la función separados por `,`.
Si tenemos una función:
```cs
MiFuncion(A,B){
    return=A+B;
}
```
Y luego hacemos una llamada a esa función desde otra:
```cs
MiOtraFuncion(){
return=MiFuncion(2,4);
}
```
>Valor de retorno: 6

Si no se le asigna ningún valor a la variable *`return`* al terminar la función esta devolverá 0.

#### Condición *`If`*
La condicional *`If`* se utiliza al igual que en C++, seguirá la misma sintaxis que de costumbre:
```cs
if(Condition){
   // Code
}
```
No se puede dejar de usar llaves para declarar el bloque de código afectado por la condición, ya que esto incurriría en un error de sintaxis. Se creará un contexto nuevo para ese bloque de código dentro de la condición. No existe la palabra reservada `else`. La condición tendrá un valor entero por supuesto, 0 para representar falso y todo otro valor es verdadero al usar operadores booleanos tipo && y || el resultado sera 1 o 0 para verdadero y falso respectivamente.

#### Ciclo *`While`*
El uso de ciclos está restringido al While, es muy similar al If, se creará un contexto nuevo para todo aquello dentro de llaves, y el desuso de esta incurrirá en un error de sintaxis.
```cs
while(Condition){
    //Code
}
```
Ejemplo:
```cs
MiFuncion(){
    i=0;
    a=1;
    while(i<10){
        a=a*2;
        i=i+1;
    }
    return=a;
}
```
>Valor de retorno: 1024

#### Operadores y símbolos
Los Operadores permitidos son muchos ya conocidos:
- Aritméticos: `+,-,*,/,%`
- Booleanos: `&&,||,!,!=,==,<=,>=,<,>`
- Bit a Bit: `&,|,^,~`
- Asignación: `=`
 
No se ha implementado operadores de incremento (`++` o `--`) , ni tampoco de autoasignación con operaciones( `+=`,`*=`), asi que debe tene cuidado ya que usted puede incurrir en errores de sintaxis debido a costumbres de otros lenguajes. Se puede usar paréntisis para cambiar la prioridad en el orden de las operaciones

#### Variable *`Random`*
Cada vez que usted haga alguna llamada a función, en el contexto global se asignara una variable llamada `Random`, que precisamnte contiene un valor Random para que usted use. Este valor cambiara cada vez que usted ejecute una función del script.

### Ingeniería de Software
Definitivamente la parte mas complicada del proyecto fue crear este pequeño compilador que les traemos, para ello usamos un Parser, un Lexer y bueno el Árbol de Sintaxis Abstracto. 

Para el Lexer usamos un Automata de Simbolos del lenguaje llamado `LexAutomaton` este se apoya en la clase Jerarchy que contiene la tabla de Jerarquía de estos símbolos.

El Parser usa un metodo recursivo Top-Down a la hora de Parsear, ya que es mucho mas sencillo de programar.Para parsear expresiones simples, consiste en encontrar el operador de menor jerarquia y Parsear ambos lados(Izq. Der.) recursivamente. Para expresiones compuestas busca llaves y `;` para ir separando todos aquellos bloques de códigos dentro de llaves, a estos los llamamos Bloques de Comandos(`ComandBlock`) y se parsean recursivamente, ya que un Bloque de Comandos esta formado por expresiones simples como:
```cs
mid=(a+b)/2;
```
o expresiones que contenga bloques de comando:
```cs
if(Condition){
    //Code
}
```
Durante todo el proceso de parseo se usa varias veces el metodo Extensor `Sublist` (que se encuentra en el namespace Extensors) que te devuelve una lista con los elementos de un rango especificado. Ejemplo:
```cs
List<int> A=new List<int>(){0,2,7,3,4,6};
List<int> B=A.Sublist(1,4);
foreach(var num in B){
    Console.Write(num+" ");
}
```
>2 7 3 4

La estructura del AST es simple, cada nodo contiene un Validador que depende del contexto, el parser se encarga de construirlo. Mi AST esta formado por Declaracion de Funciones y Declaracion de Variables Globales. Todas guardadas en un objeto de tipo **IContext**: `MainContext`.

Para Correr alguna de las funciones del AST se usa el metodo: 
```cs
public string RunFunction(string Name,List<string> Params);
```

## Creación de cartas
### Archivos
Para crear una carta usted debe dirigirse a la carpeta `Game\Cards` , crear una carpeta con el nombre de su nueva carta, y dentro colocar el Script en formato .txt junto con otro archivo .txt llamado Info. El script tambien deberá llevar el nombre de la carta, el contenido de una carpeta llamada `Winter Wyvern` debería ser el siguiente:
```
Info.txt
Winter Wyvern.txt
```
Si el archivo tiene algun error de compilación aparecerá en el juego pero cuando intente escogerlo, le aparecerá un mensaje de diciendo que la carta tiene algunos errores y no podrá jugar con ella, por otro lado si se equivoca con el formato que deben tener la carpeta y el txt con el mismo nombre, la carta no aparecerá en el catálogo. No crear un archivo Info.txt incurrirá en que cuando intente ver la Información de la carta aparecerá el texto "No Info".

### Sintaxis `Perform`
El juego consiste en un conjunto de acciones como Atacar, Lanzar algún poder mágico, Curar, o activar Buffs. Como se dijo anteriormente los contextos de las cartas no estan entrelazados por lo que es limitado lo que se puede hacer. En el archivo base.txt estan programadas ciertas estadísticas y funciones que las cartas tienen por defecto, para que el juego sepa que funciones de la carta pueden ser utilizadas por el jugador las funciones deberán seguir la siguiente sintaxis:
```cs
Perform_MyFunction(){
    //Code
}
```
La función debera llevar delante `Perform_` hay ciertas acciones especiales que son `Attack`,`Heal`,`Buff`,`Buff1`,`Buff2` las dos primeras son para atacar a otros jugadores y curar a los tuyos respectivamente, los Buff son para Subir tus propias stats mayormente, cualquier otra función que no sea ninguna de las anteriores y lleve `Perform_` delante seran interpretados como ataques magicos(Para esto la stat de mana, encárguese responsablemente de que cada funcion de este tipo incurra en un costo de Mana), el valor de retorno de estas últimas se interpretarán como daño mágico sobre otras cartas. La forma en la que las cartas manejan ser curadas, ser atacadas o ser atacadas con magia estan dadas por las funciones `Handle_Heal`,`Handle_Attack` y `Handle_Magic` respectivamente(estas estan en base.txt) usted es libre de sobreescribirlas solo tiene que volver a declararlas en su código de la carta(Asegúrese de que la Stat Armor influya de alguna manera sobre `Handle_Attack`).

### Sintaxis `Get`
El estado actual de cada carta se guarda directamente en el contexto de la carta como vairable globales, para acceder a las Stats, C# usa una funcion GetStat(*statname*) por eso le sugerimos que por convención cuando vaya a crear una stat nueva use el siguiente formato en su código de carta, para que C# pueda acceder a ella:
```cs
Get_NewStat(){
    return=NewStat;
}
```

### Sintaxis `Handle`
Esto sigue en desarrollo pero para actualizaciones futuras se tiene previsto que la sintaxis Handle se use para manejar efectos de estados alterados como Poison y Stun, que debería ser la encargada de decidir como la carta maneja este tipo de efectos al ser lanzados sobre ellos. Por ahora solo estan `Handle_Attack`,`Handle_Heal` y `Handle_Magic`.

## Interfaz Grafica
### Ingenieria de Software
Debido a la extensión de la interfaz gráfica se usaron varias clases parciales para definir una sola clase GInterface. Creamos una clase GComponent encargada de manejar los mensajes mostrados en Consola, las propiedades de esta y leer las órdenes del usuario. GInterface interactúa con GComponent de manera tal que si es necesario migrar la interfaz a una Aplicacion Visual o Web los cambios requeridos sean mínimos.

También tenemos otro método util `Wait` que se encarga de contar una determinada cantidad de milisegundos.
```cs
public void Wait(int n){
    Stopwatch F=new Stopwatch();
    F.Start();
    long d=F.ElapsedMilliseconds;
    while(true){
        if(F.ElapsedMilliseconds-d>n){
            F.Stop();
            break;
        }
    }
    }
```    