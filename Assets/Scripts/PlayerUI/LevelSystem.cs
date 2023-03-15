using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem Instance;

    public int level;
    public float currentXp;
    public float requiredXp;

    private float lerpTimer;
    private float delayTimer;
    public float chipSpeed = 2f;

    [Header("UI")] public Image frontXpBar;
    public Image backXpBar;

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI xpText;

    [Header("Multipliers")] 
    [Range(1f, 300f)]
    public float additionMultiplier = 300;
    [Range(2f, 4f)] 
    public float powerMultiplier = 2;
    [Range(7f, 14f)] 
    public float divisionMultiplier = 7;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        frontXpBar.fillAmount = currentXp / requiredXp;
        backXpBar.fillAmount = currentXp / requiredXp;
        requiredXp = CalculateRequiredXp();
        levelText.text = "Level " + level;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateXpUI();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GainExperienceFlatRate(20);
        }

        if (currentXp > requiredXp)
        {
            LevelUp();
        }
    }

    public void UpdateXpUI()
    {
        var xpFraction = currentXp / requiredXp;
        var FXP = frontXpBar.fillAmount;
        if (FXP < xpFraction)
        {
            delayTimer += Time.deltaTime;
            backXpBar.fillAmount = xpFraction;
            if (delayTimer > 1)
            {
                lerpTimer += Time.deltaTime;
                var percentComplete = lerpTimer / chipSpeed;
                frontXpBar.fillAmount = Mathf.Lerp(FXP, backXpBar.fillAmount, percentComplete);
            }
        }

        xpText.text = currentXp + "/" + requiredXp;
    }

    public void GainExperienceFlatRate(float xpGained)
    {
        currentXp += xpGained;
        lerpTimer = 0f;
        delayTimer = 0f;
    }

    public void GainExperienceScalable(float xpGained, int passedLevel)
    {
        if (passedLevel < level)
        {
            var multiplier = 1 + (level - passedLevel) * 0.1f;
            currentXp += xpGained * multiplier;
        }
        else
        {
            currentXp += xpGained;
        }

        lerpTimer = 0f;
        delayTimer = 0f;
    }

    public void LevelUp()
    {
        level++;
        frontXpBar.fillAmount = 0f;
        backXpBar.fillAmount = 0f;
        currentXp = Mathf.RoundToInt(currentXp - requiredXp);
        //GetComponent<PlayerHealth>().IncreaseHealth(level);
        requiredXp = CalculateRequiredXp();
        levelText.text = "Level " + level;
    }

    private int CalculateRequiredXp()
    {
        var solveForRequiredXp = 0;
        for (var levelCycle = 1; levelCycle <= level; levelCycle++)
        {
            solveForRequiredXp += (int)Mathf.Floor(levelCycle +
                                                   additionMultiplier * Mathf.Pow(powerMultiplier,
                                                       levelCycle / divisionMultiplier));
        }

        return solveForRequiredXp / 4;
    }
}