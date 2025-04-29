using System.Linq;
using TMPro;
using UnityEngine;
//using System.Drawing;

//By RetrKill0
public class PlateGenerator : MonoBehaviour
{
    // Componentes de texto para as placas da frente e traseira da placa 1
    public TextMeshPro plate1FrontText;
    public TextMeshPro plate1RearText;

    // Componentes de texto para as placas da frente e traseira da placa 2
    public TextMeshPro plate2FrontText;
    public TextMeshPro plate2RearText;
    //public Color[] plateColors; // Array de cores para as placas

    //Validar se vai funcionar
    private bool shouldGeneratePlates = false; //(validar se vai dar bom)
    public GameObject hiddenPiece; //Vou pro o gameobject vaio com as 2 placas dentro (aonde vai ficar o script talvez?)
    public GameObject linkedPiece;

    //private void Start()
    //{
    //    // Chama as fun��es para gerar as placas no in�cio do jogo - PARA TESTE
    //    GeneratePlate1();
    //    GeneratePlate2();
    //}

    //private void Awake()
    //{
    //    bool isPieceVisible = hiddenPiece.activeSelf;

    //    if (isPieceVisible)
    //    {
    //        shouldGeneratePlates = true;
    //    }

    //    linkedPiece.SetActive(isPieceVisible);

    //    if (shouldGeneratePlates)
    //    {
    //        GeneratePlate1();
    //        GeneratePlate2();
    //    }
    //}

    private void OnEnable()
    {

        GeneratePlate1();
        GeneratePlate2();
        //// Verifica se o objeto hiddenPiece est� ativo
        //if (hiddenPiece.activeSelf)
        //{
        //    GeneratePlate1();
        //    GeneratePlate2();
        //}
    }

    private string GenerateRandomSequenceForPlate1()
    {
        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string numbers = "0123456789";
        string part1 = new(Enumerable.Repeat(letters, 3).Select(s => s[Random.Range(0, s.Length)]).ToArray());
        string part2 = numbers[Random.Range(0, numbers.Length)].ToString();
        string part3 = new(Enumerable.Repeat(letters, 1).Select(s => s[Random.Range(0, s.Length)]).ToArray());
        string part4 = new(Enumerable.Repeat(numbers, 2).Select(s => s[Random.Range(0, numbers.Length)]).ToArray());

        return $"{part1} {part2}{part3}{part4}";
    }

    private string GenerateRandomSequenceForPlate2()
    {
        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string numbers = "0123456789";
        string part1 = new(Enumerable.Repeat(letters, 3).Select(s => s[Random.Range(0, s.Length)]).ToArray());
        string part2 = new(Enumerable.Repeat(numbers, 4).Select(s => s[Random.Range(0, numbers.Length)]).ToArray());

        return $"{part1}-{part2}";
    }

    public void GeneratePlate1()
    {
        string sequenceForPlate1 = GenerateRandomSequenceForPlate1();

        if (plate1FrontText != null && plate1RearText != null)
        {
            ApplyPlateInfo(plate1FrontText, sequenceForPlate1);
            ApplyPlateInfo(plate1RearText, sequenceForPlate1);
        }
    }

    public void GeneratePlate2()
    {
        string sequenceForPlate2 = GenerateRandomSequenceForPlate2();

        if (plate2FrontText != null && plate2RearText != null)
        {
            ApplyPlateInfo(plate2FrontText, sequenceForPlate2);
            ApplyPlateInfo(plate2RearText, sequenceForPlate2);
        }
    }

    private void ApplyPlateInfo(TextMeshPro plateText, string sequence)
    {
        if (plateText != null)
        {
            plateText.text = sequence.ToUpper();
        }
    }
    //private void ApplyPlateInfo(TextMeshPro plateText, string sequence) //Color color
    //{
    //    //color.a = 1; // Garante que a cor seja opaca
    //    //plateText.color = color;
    //    plateText.text = sequence.ToUpper();
    //}

    //public void AtivarHiddenPiece()
    //{

    //}

    public void CheckLicence()
    {
        hiddenPiece.SetActive(true);

        bool isPieceVisible = hiddenPiece.activeSelf;

        if (isPieceVisible)
        {
            shouldGeneratePlates = true;
        }

        linkedPiece.SetActive(isPieceVisible);

        if (shouldGeneratePlates)
        {
            GeneratePlate1();
            GeneratePlate2();
        }
    }
}
