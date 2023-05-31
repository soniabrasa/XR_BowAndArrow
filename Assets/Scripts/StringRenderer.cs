using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(LineRenderer))]
public class StringRenderer : MonoBehaviour
{
    [Header("Settings")]
    public Gradient pullColor = null;

    [Header("References")]
    public PullMeasurer pullMeasurer = null;

    [Header("Render Positions")]
    public Transform start = null;
    public Transform middle = null;
    public Transform end = null;

    private LineRenderer lineRenderer = null;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        // Mientras estás en el editor,
        // asegúrate de que el LineRenderer siga el arco

        //if (Application.isEditor && !Application.isPlaying)
        UpdatePositions();
    }

    private void OnEnable()
    {
        // Actualizar antes de renderizar da mejores resultados
        Application.onBeforeRender += UpdatePositions;

        // Al ser tirado, actualiza el color
        pullMeasurer.Pulled.AddListener(UpdateColor);
    }

    private void OnDisable()
    {
        Application.onBeforeRender -= UpdatePositions;
        pullMeasurer.Pulled.RemoveListener(UpdateColor);
    }

    private void UpdatePositions()
    {
        // Establece las posiciones del LineRenderer
        // La middle.position es la unión del Notch
        Vector3[] positions = new Vector3[] {
            start.position, middle.position, end.position
        };

        lineRenderer.SetPositions(positions);
    }

    private void UpdateColor(Vector3 pullPosition, float pullAmount)
    {
        // Usando el degradado, muestra el valor vía string color
        Color color = pullColor.Evaluate(pullAmount);
        lineRenderer.material.color = color;
    }
}
