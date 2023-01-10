using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GA : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


/*
 using UnityEngine.UI;
using UnityEngine;


public class GA : MonoBehaviour
{
    int GENE_LENGTH = GenerateHints.GENE_LENGTH;     //遺伝子長
    int GENERATION = GenerateHints.GENERATION;      //世代数
    int PROGRAM_NUMBER = GenerateHints.PROGRAM_NUMBER;  //1世代の個体数

    int LOGIC = GenerateHints.LOGIC;   //ロジックタグの数
    int INPUT = GenerateHints.INPUT;   //Inputタグの数
    int OUTPUT = GenerateHints.OUTPUT;  //Outputの数
    int MONO = GenerateHints.MONO;   //モノの数

    int FIRST_PROBABILITY = GenerateHints.FIRST_PROBABILITY;      //1位の選択確率?
    int SECOND_PROBABILITY = GenerateHints.SECOND_PROBABILITY;     //2位の選択確率
    int THIRD_PROBABILITY = GenerateHints.THIRD_PROBABILITY;      //3位の選択確率
    int FOURTH_PROBABILITY = GenerateHints.FOURTH_PROBABILITY;     //4位の選択確率
    int FIFTH_PROBABILITY = GenerateHints.FIFTH_PROBABILITY;      //5位の選択確率

    int MUTATION_PROBABILITY = GenerateHints.MUTATION_PROBABILITY;    //突然変異率

    float SIZE = GenerateHints.SIZE;             //Canvasの大きさ変更時使用

    int now_generation = GenerateHints.now_generation;                                     //現在の世代
    int now_program_number = GenerateHints.now_program_number;                                 //現在の個体
    int[] one_program = GenerateHints.one_program;                   //表示用（1個体保存）
    int[] elite_program = GenerateHints.elite_program;                 //エリート保存
    int[,] program = GenerateHints.program;      //遺伝子配列
    int[,] tmp_program = GenerateHints.tmp_program;  //遺伝子配列（ソートと次の世代用）
    int[,] back_program = GenerateHints.back_program; //遺伝子配列（戻る用
    int[,] evaluation = GenerateHints.evaluation;    //世代ごとの評価値を格納

    // GenerateHints GH = new GenerateHints();

    //GA処理
    public void GA_processing()
    {
        //エリート保存
        int max = 0;    //最高点

        for (int i = 0; i < PROGRAM_NUMBER - 1; i++)
        {
            if (max <= evaluation[now_generation, i])
            {
                max = evaluation[now_generation, i];

                for (int j = 0; j < GENE_LENGTH; j++)
                {
                    elite_program[j] = program[i, j];
                }
            }
        }

        //選択
        Select();

        //交叉
        Crossover();

        //突然変異
        Mutation();

        //最後の個体をエリートと入れ替え
        for (int i = 0; i < GENE_LENGTH; i++)
        {
            program[PROGRAM_NUMBER - 1, i] = elite_program[i];
        }

        //世代を+1
        now_generation++;

        //個体番号を初期化
        now_program_number = 0;
    }

    //選択(ランク方式)
    public void Select()
    {
        int sum = 0;

        //選択確率の総和を求める
        for (int i = 0; i < PROGRAM_NUMBER; i++)
        {
            if (evaluation[now_generation, i] == 5)
                sum += FIRST_PROBABILITY;

            else if (evaluation[now_generation, i] == 4)
                sum += SECOND_PROBABILITY;

            else if (evaluation[now_generation, i] == 3)
                sum += THIRD_PROBABILITY;

            else if (evaluation[now_generation, i] == 2)
                sum += FOURTH_PROBABILITY;

            else if (evaluation[now_generation, i] == 1)
                sum += FIFTH_PROBABILITY;
        }

        //順位に応じた選択数に基づいてルーレット選択
        for (int i = 0; i < PROGRAM_NUMBER; i++)
        {
            //0?sumのランダムな値を格納
            int rnd = 0;
            rnd = UnityEngine.Random.Range(0, sum);

            int sum2 = 0;    //確率の合計
            int count = 0;   //カウンター

            do
            {
                if (rnd < sum2)
                {
                    for (int k = 0; k < GENE_LENGTH; k++)
                    {
                        tmp_program[i, k] = program[i, k];
                    }
                    break;
                }

                else
                {
                    if (evaluation[now_generation, count] == 5)
                        sum2 += FIRST_PROBABILITY;

                    else if (evaluation[now_generation, count] == 4)
                        sum2 += SECOND_PROBABILITY;

                    else if (evaluation[now_generation, count] == 3)
                        sum2 += THIRD_PROBABILITY;

                    else if (evaluation[now_generation, count] == 2)
                        sum2 += FOURTH_PROBABILITY;

                    else if (evaluation[now_generation, count] == 1)
                        sum2 += FIFTH_PROBABILITY;

                    count++;
                }

            } while (sum >= sum2);
        }
    }

    //交叉(一様交叉)
    public void Crossover()
    {
        for (int i = 0; i < PROGRAM_NUMBER; i = i + 2)
        {
            for (int k = 0; k < GENE_LENGTH; k++)
            {
                //0?99のランダムな値を格納
                int rnd = 0;
                rnd = UnityEngine.Random.Range(0, 99);

                //Maskは毎回生成
                //交叉する場合
                if (rnd < 50)
                {
                    program[i, k] = tmp_program[i + 1, k];
                    program[i + 1, k] = tmp_program[i, k];
                }

                //交叉しない場合
                else
                {
                    program[i, k] = tmp_program[i, k];
                    program[i + 1, k] = tmp_program[i + 1, k];
                }
            }
        }
    }

    //突然変異
    public void Mutation()
    {
        //0?99のランダムな値を格納
        int rnd = 0;

        //8個体目はエリートになるため変異なし
        for (int i = 0; i < PROGRAM_NUMBER - 1; i++)
        {
            //突然変異率に応じて変異するか決定
            rnd = UnityEngine.Random.Range(0, 99);

            if (rnd < MUTATION_PROBABILITY)
            {
                //変異する遺伝子を決定
                int rnd2 = UnityEngine.Random.Range(0, GENE_LENGTH);

                if (rnd2 == 0)
                    program[i, 0] = UnityEngine.Random.Range(0, LOGIC);

                else if (rnd2 == 1)
                    program[i, 1] = UnityEngine.Random.Range(0, INPUT);

                else if (rnd2 == 2)
                    program[i, 2] = UnityEngine.Random.Range(0, INPUT);

                else if (rnd2 == 3)
                    program[i, 3] = UnityEngine.Random.Range(0, OUTPUT);

                else if (rnd2 == 4)
                    program[i, 4] = UnityEngine.Random.Range(0, OUTPUT);

                else if (rnd2 == 5)
                    program[i, 5] = UnityEngine.Random.Range(0, MONO);

                else if (rnd2 == 6)
                    program[i, 6] = UnityEngine.Random.Range(0, MONO);
            }

            //タグが重複したとき（同じInput,Output,モノ）は強制的に変異+ボタンタグが重複したとき
            if (program[i, 1] == program[i, 2] || (program[i, 1] == 3 && program[i, 2] == 4) || (program[i, 1] == 4 && program[i, 2] == 3))
            {
                while (program[i, 1] == program[i, 2] || (program[i, 1] == 3 && program[i, 2] == 4) || (program[i, 1] == 4 && program[i, 2] == 3))
                {
                    program[i, 2] = UnityEngine.Random.Range(0, INPUT);
                };
            }

            if (program[i, 3] == program[i, 4])
            {
                while (program[i, 3] == program[i, 4])
                {
                    program[i, 4] = UnityEngine.Random.Range(0, OUTPUT);
                };
            }

            if (program[i, 5] == program[i, 6])
            {
                while (program[i, 5] == program[i, 6])
                {
                    program[i, 6] = UnityEngine.Random.Range(0, MONO);
                };
            }
        }
        /*

        //突然変異率に応じて各遺伝子をランダムな値に変更
        for (int i = 0; i < PROGRAM_NUMBER - 1; i++)
        {
            rnd = UnityEngine.Random.Range(0, 99);
            if (rnd < MUTATION_PROBABILITY)
                program[i, 0] = UnityEngine.Random.Range(0, LOGIC);

            rnd = UnityEngine.Random.Range(0, 99);
            if (rnd < MUTATION_PROBABILITY)
                program[i, 1] = UnityEngine.Random.Range(0, INPUT);

            rnd = UnityEngine.Random.Range(0, 99);
            if (rnd < MUTATION_PROBABILITY)
                program[i, 2] = UnityEngine.Random.Range(0, INPUT);

            //タグが重複したとき（同じInput,Output,モノ）は強制的に変異+ボタンタグが重複したとき
            if (program[i, 1] == program[i, 2] || (program[i, 1] == 3 && program[i, 2] == 4))
            {
                while (program[i, 1] == program[i, 2])
                {
                    program[i, 2] = UnityEngine.Random.Range(0, INPUT);
                };
            }

            rnd = UnityEngine.Random.Range(0, 99);
            if (rnd < MUTATION_PROBABILITY)
                program[i, 3] = UnityEngine.Random.Range(0, OUTPUT);

            rnd = UnityEngine.Random.Range(0, 99);
            if (rnd < MUTATION_PROBABILITY)
                program[i, 4] = UnityEngine.Random.Range(0, OUTPUT);


            if (program[i, 3] == program[i, 4])
            {
                while (program[i, 3] == program[i, 4])
                {
                    program[i, 4] = UnityEngine.Random.Range(0, OUTPUT);
                };
            }

            rnd = UnityEngine.Random.Range(0, 99);
            if (rnd < MUTATION_PROBABILITY)
                program[i, 5] = UnityEngine.Random.Range(0, MONO);

            rnd = UnityEngine.Random.Range(0, 99);
            if (rnd < MUTATION_PROBABILITY)
                program[i, 6] = UnityEngine.Random.Range(0, MONO);

            if (program[i, 5] == program[i, 6])
            {
                while (program[i, 5] == program[i, 6])
                {
                    program[i, 6] = UnityEngine.Random.Range(0, MONO);
                };
            }
        }
        
    }

    public void initialize()
{
    // 初期化
    now_generation = 0;                                  //現在の世代
    now_program_number = 0;                              //現在の個体
    one_program = new int[GENE_LENGTH];                  //表示用（1個体保存）
    elite_program = new int[GENE_LENGTH];                //エリート保存
    program = new int[PROGRAM_NUMBER, GENE_LENGTH];      //遺伝子配列
    tmp_program = new int[PROGRAM_NUMBER, GENE_LENGTH];  //遺伝子配列（ソートと次の世代用）
    back_program = new int[PROGRAM_NUMBER, GENE_LENGTH]; //遺伝子配列（戻る用）
    evaluation = new int[GENERATION, PROGRAM_NUMBER];    //世代ごとの評価値を格納
}

}


 
 
 
 
 
 */