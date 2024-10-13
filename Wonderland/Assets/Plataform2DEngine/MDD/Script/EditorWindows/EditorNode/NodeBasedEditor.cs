using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
 
public class NodeBasedEditor : EditorWindow
{
    private List<Node> nodes;
    private List<Connection> connections;
 
    private GUIStyle nodeStyle;
    private GUIStyle selectedNodeStyle;
    private GUIStyle inPointStyle;
    private GUIStyle outPointStyle;
    private Vector2 offset;
    private Vector2 drag;
    private ConnectionPoint selectedInPoint;
    private ConnectionPoint selectedOutPoint;
 
    [MenuItem("Window/Node Based Editor2")]
    private static void OpenWindow()
    {
        NodeBasedEditor window = GetWindow<NodeBasedEditor>();
        window.titleContent = new GUIContent("Node Based Editor");
    }

    private void OnEnable()
    {
        nodeStyle = new GUIStyle();
        nodeStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/node1.png") as Texture2D;
        nodeStyle.border = new RectOffset(12, 12, 12, 12);

        selectedNodeStyle = new GUIStyle();
        selectedNodeStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/node1 on.png") as Texture2D;
        selectedNodeStyle.border = new RectOffset(12, 12, 12, 12);

        inPointStyle = new GUIStyle();
        inPointStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn left.png") as Texture2D;
        inPointStyle.active.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn left on.png") as Texture2D;
        inPointStyle.border = new RectOffset(4, 4, 12, 12);

        outPointStyle = new GUIStyle();
        outPointStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn right.png") as Texture2D;
        outPointStyle.active.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn right on.png") as Texture2D;
        outPointStyle.border = new RectOffset(4, 4, 12, 12);
    }
    //Funcion especial para dibujar una interfaz //Esta funcionanando mandandole mesajes a el directx para que dibuje 
    private void OnGUI()
    {
        //Dibja la grilla 
        DrawGrid(20, 0.2f, Color.red);
        DrawGrid(100, 0.4f, Color.red);

        //Dibuja Los Nodos
        DrawNodes();
        //Dibuja las conneciones
        DrawConnections();

        //Esto prmite dibujar en momentos expesificos cuando se ejecutan los eventos respectivos y no siempre
        //Dibuja lines de conecciones el evento correspondiente
        DrawConnectionLine(Event.current);

        //Dibujar ls eventos de los nodos 
        ProcessNodeEvents(Event.current);
        //Dibujar los eventos de procesos como los click del mouse.
        ProcessEvents(Event.current);

        if (GUI.changed) Repaint();
    }
    //Dibuja los nodos
    private void DrawNodes()
    {
        //Los nodos deben existir
        if (nodes != null)
        {
            //Recorre todos los nodos y los dibuja //Siempre los dibuja
            for (int i = 0; i < nodes.Count; i++)
            {

                nodes[i].Draw();
            }
        }
    }

    //Dibuja la coneccion  de los nodos
    private void DrawConnections()
    {
        //la connecion debe ser diferente de null.
        if (connections != null)
        {
            //Recorre las conecciones y este las dibuja (SIEMPRE)
            for (int i = 0; i < connections.Count; i++)
            {
                connections[i].Draw();
            }
        }
    }


    private void ProcessEvents(Event e)
    {
        drag = Vector2.zero;

        switch (e.type)
        {
            //esto requiere que el mouse precione una sola vez

            case EventType.MouseDown:
                //esto permite selecionar la coneccion este laelimina 
                if (e.button == 0)
                {
                    ClearConnectionSelection();
                }

                //Cuando se ejecuta el click derecho generando un pequeño menu para elejir opciones como agregar nodo o eliminar nodo
                if (e.button == 1)
                {
                    ProcessContextMenu(e.mousePosition);
                }
                break;

            //Este caso es el movimiento del mouse que ejecuta la funcion OnDrag(e.delta);
            //Esto se ejecuta cada vez que se desplaze el nodo seleccionado usando claro el click izquierdo precionado
            case EventType.MouseDrag:
                if (e.button == 0)
                {
                    OnDrag(e.delta);
                }
                break;
        }
    }


    //processa los eventos de los nodos
    private void ProcessNodeEvents(Event e)
    {
        // el nodo debe existir
        if (nodes != null)
        {
            //Se recorre la lista de los nodos desde el ultimo al primero menos -1 ya que siempre en un array comienza desde 0 en adelante
            for (int i = nodes.Count - 1; i >= 0; i--)
            {
                //se genera una variable guiChanged que controla los cambios y esta es igual al evento de ese nodo determinado
                bool guiChanged = nodes[i].ProcessEvents(e);
                //Este controla si los cambios se hacen o no para poder manipular un nodo a la vez
                if (guiChanged)
                {
                    GUI.changed = true;
                }
            }
        }
    }

    //Esto Crea un menu de seleccion estandar al momento de realizar el click derecho
    private void ProcessContextMenu(Vector2 mousePosition)
    {
        GenericMenu genericMenu = new GenericMenu();
        genericMenu.AddItem(new GUIContent("Add node"), false, () => OnClickAddNode(mousePosition));
        genericMenu.ShowAsContext();
    }

    //Esto crea unnuevo nodo si este es null con el ckick del mouse
    private void OnClickAddNode(Vector2 mousePosition)
    {
        if (nodes == null)
        {
            nodes = new List<Node>();
        }
        //Esto crea un nodo con las funciones asociadas estilos de letra y unciones correspondientes que se cargan en esta clas
        nodes.Add(new Node(mousePosition, 200, 50, nodeStyle, selectedNodeStyle, inPointStyle, outPointStyle, OnClickInPoint, OnClickOutPoint, OnClickRemoveNode));
    }
    //Clase de control para el uso de los vinculos este es el vinculo de entrada el que se une al extremo izquierdo
    private void OnClickInPoint(ConnectionPoint inPoint)
    {

        selectedInPoint = inPoint;

        if (selectedOutPoint != null)
        {
            if (selectedOutPoint.node != selectedInPoint.node)
            {
                CreateConnection();
                ClearConnectionSelection();
            }
            else
            {
                ClearConnectionSelection();
            }
        }
    }

    //clase de control para el uso de los vinculos de salida al extremo derecho
    private void OnClickOutPoint(ConnectionPoint outPoint)
    {
        //lo que hace es ogialar el puntode salida selecionado con el que se a elegido con el crosr
        selectedOutPoint = outPoint;

        //el elemento seleccionado tiene que ser diferente que null
        if (selectedInPoint != null)
        {
            //El elemento selecionado de lalida tiene que ser diferente al de entrada no seleccionado
            if (selectedOutPoint.node != selectedInPoint.node)
            {
                //Si esto se cumple se crea una connecion 
                CreateConnection();
                //Se elimina el elemento en la lista de seleccion
                ClearConnectionSelection();
            }
            else
            {
                // encaso de no ser asi, se limia la coneccion selecionada
                ClearConnectionSelection();
            }
        }
    }
    //remueve la coneccio establecida entre los nodos
    //Esto no hay que tocarlo
    private void OnClickRemoveConnection(Connection connection)
    {
        connections.Remove(connection);
    }
    //Crea una coneccion entre los dos nodos
    private void CreateConnection()
    {
        //si no hay una una lista de conecciones creada crea una nueva lista
        if (connections == null)
        {
            connections = new List<Connection>();
        }
        //Añade el elemento de entrada de una coneccion con el elemento de entrada con uno de salida establecindo una coneccion y avilita la opcion de eliminar el vinculo
        connections.Add(new Connection(selectedInPoint, selectedOutPoint, OnClickRemoveConnection));
    }

    //Elimina la coneccion seleccionada etableciendo los valors de entrada y salida de la coneccion selecionada
    private void ClearConnectionSelection()
    {
        selectedInPoint = null;
        selectedOutPoint = null;
    }

    //esto cre un pequeño cuadro en la mitad de la coneccion que permite eliminar la coneccion entre los nodos
    private void OnClickRemoveNode(Node node)
    {
        //tiene que exisir una conneccion 
        if (connections != null)
        {
            //Se crea una nueva lista la cual amacena los elementos que se elminan es para almacenar temporalmente
            List<Connection> connectionsToRemove = new List<Connection>();

            //si la connecion enn la lista entrante coincide con la de la lista de nodos almacenados o la lista out coincde con el node out tambien
            //esta conneion es agregada a la lista de conneciones removidas
            for (int i = 0; i < connections.Count; i++)
            {
                if (connections[i].inPoint == node.inPoint || connections[i].outPoint == node.outPoint)
                {
                    connectionsToRemove.Add(connections[i]);
                }
            }

            //Luego la lista de conneciones es Recorrida y luego la elimina si esta es igual a la cantidad de conecciones almacenadas para eliminar
            for (int i = 0; i < connectionsToRemove.Count; i++)
            {
                connections.Remove(connectionsToRemove[i]);
            }
            //la lista despues es igualada a null
            connectionsToRemove = null;
        }
        //y los nodos son eliminados siendo comparados con los nodos de la lista general que fueron pasados por parametro
        nodes.Remove(node);
    }
    private void OnDrag(Vector2 delta)
    {
        //Se iguala el vector de despazaminto al vector "Delta"
        //TODO:investigar sobre el vector delta en unity
        drag = delta;

        //el nodo si es diferente a null entonces los nodos son recorridos y elecutando la Drag
        if (nodes != null)
        {
            //Se recorren los nodos
            //Se actualiza la posicion de todos los nodos 
            for (int i = 0; i < nodes.Count; i++)
            {
                //Se actualiza su posicion 
                nodes[i].Drag(delta);
            }
        }
        //Se aplican los cambios
        GUI.changed = true;
    }
    //Dibuja las lineas de connecion esto se usa mediante un evento para que no se de el problema de que el evento no termine y se siga ejecutando 
    private void DrawConnectionLine(Event e)
    {
        //Si el SelectedInPoint no es null per el out point si es null etonces lo qu hace es dibujar la linea que es enclada y arrastrada por el mouse
        if (selectedInPoint != null && selectedOutPoint == null)
        {
            //Esto dibuja la linea que se mueve con el cursor
            Handles.DrawBezier(
                selectedInPoint.rect.center,
                e.mousePosition,
                selectedInPoint.rect.center + Vector2.left * 50f,
                e.mousePosition - Vector2.left * 50f,
                Color.white,
                null,
                2f
            );

            GUI.changed = true;
        }
        //Viseversa del primer caso esto es if ya que se tiene que ejecutar siempre que suceda en vez de ser otro caso 
        if (selectedOutPoint != null && selectedInPoint == null)
        {
            Handles.DrawBezier(
                selectedOutPoint.rect.center,
                e.mousePosition,
                selectedOutPoint.rect.center - Vector2.left * 50f,
                e.mousePosition + Vector2.left * 50f,
                Color.white,
                null,
                2f
            );

            GUI.changed = true;
        }
    }
    //Dibuja la grilla en la cual se ven los objetos
    //Esto es mas opcional ya que lo que hace es dibujar un fondo nada mas

    private void DrawGrid(float gridSpacing, float gridOpacity, Color gridColor)
    {
        //Calcila la distancia media del espacio de alto dividido el tamañp de la girlla
        //Calcula el hacho con la mitad del tamaño de la girlla 
        //Mathf biblioteca matematica de unity
        //Mathf.CeilToInt devuelve el entermo menor o igual al flotane que se le pase (esto lo que hace es "Redondear"
        int widthDivs = Mathf.CeilToInt(position.width / gridSpacing);
        int heightDivs = Mathf.CeilToInt(position.height / gridSpacing);

        //Dibuja al principio de todo 
        Handles.BeginGUI();
        //le asigna el color en rgbA de el menu
        Handles.color = new Color(gridColor.r, gridColor.g, gridColor.b, gridOpacity);

        //Ajusta el offten drag 
        offset += drag * 0.5f;
        //Ajusta el offset del background
        Vector3 newOffset = new Vector3(offset.x % gridSpacing, offset.y % gridSpacing, 0);
        //asigna el offsent de las lineas en el background

        for (int i = 0; i < widthDivs; i++)
        {
            Handles.DrawLine(new Vector3(gridSpacing * i, -gridSpacing, 0) + newOffset, new Vector3(gridSpacing * i, position.height, 0f) + newOffset);
        }

        for (int j = 0; j < heightDivs; j++)
        {
            Handles.DrawLine(new Vector3(-gridSpacing, gridSpacing * j, 0) + newOffset, new Vector3(position.width, gridSpacing * j, 0f) + newOffset);
        }

        Handles.color = Color.white;
        Handles.EndGUI();
    }

}