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
    int GENE_LENGTH = GenerateHints.GENE_LENGTH;     //��`�q��
    int GENERATION = GenerateHints.GENERATION;      //���㐔
    int PROGRAM_NUMBER = GenerateHints.PROGRAM_NUMBER;  //1����̌̐�

    int LOGIC = GenerateHints.LOGIC;   //���W�b�N�^�O�̐�
    int INPUT = GenerateHints.INPUT;   //Input�^�O�̐�
    int OUTPUT = GenerateHints.OUTPUT;  //Output�̐�
    int MONO = GenerateHints.MONO;   //���m�̐�

    int FIRST_PROBABILITY = GenerateHints.FIRST_PROBABILITY;      //1�ʂ̑I���m��?
    int SECOND_PROBABILITY = GenerateHints.SECOND_PROBABILITY;     //2�ʂ̑I���m��
    int THIRD_PROBABILITY = GenerateHints.THIRD_PROBABILITY;      //3�ʂ̑I���m��
    int FOURTH_PROBABILITY = GenerateHints.FOURTH_PROBABILITY;     //4�ʂ̑I���m��
    int FIFTH_PROBABILITY = GenerateHints.FIFTH_PROBABILITY;      //5�ʂ̑I���m��

    int MUTATION_PROBABILITY = GenerateHints.MUTATION_PROBABILITY;    //�ˑR�ψٗ�

    float SIZE = GenerateHints.SIZE;             //Canvas�̑傫���ύX���g�p

    int now_generation = GenerateHints.now_generation;                                     //���݂̐���
    int now_program_number = GenerateHints.now_program_number;                                 //���݂̌�
    int[] one_program = GenerateHints.one_program;                   //�\���p�i1�̕ۑ��j
    int[] elite_program = GenerateHints.elite_program;                 //�G���[�g�ۑ�
    int[,] program = GenerateHints.program;      //��`�q�z��
    int[,] tmp_program = GenerateHints.tmp_program;  //��`�q�z��i�\�[�g�Ǝ��̐���p�j
    int[,] back_program = GenerateHints.back_program; //��`�q�z��i�߂�p
    int[,] evaluation = GenerateHints.evaluation;    //���ゲ�Ƃ̕]���l���i�[

    // GenerateHints GH = new GenerateHints();

    //GA����
    public void GA_processing()
    {
        //�G���[�g�ۑ�
        int max = 0;    //�ō��_

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

        //�I��
        Select();

        //����
        Crossover();

        //�ˑR�ψ�
        Mutation();

        //�Ō�̌̂��G���[�g�Ɠ���ւ�
        for (int i = 0; i < GENE_LENGTH; i++)
        {
            program[PROGRAM_NUMBER - 1, i] = elite_program[i];
        }

        //�����+1
        now_generation++;

        //�̔ԍ���������
        now_program_number = 0;
    }

    //�I��(�����N����)
    public void Select()
    {
        int sum = 0;

        //�I���m���̑��a�����߂�
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

        //���ʂɉ������I�𐔂Ɋ�Â��ă��[���b�g�I��
        for (int i = 0; i < PROGRAM_NUMBER; i++)
        {
            //0?sum�̃����_���Ȓl���i�[
            int rnd = 0;
            rnd = UnityEngine.Random.Range(0, sum);

            int sum2 = 0;    //�m���̍��v
            int count = 0;   //�J�E���^�[

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

    //����(��l����)
    public void Crossover()
    {
        for (int i = 0; i < PROGRAM_NUMBER; i = i + 2)
        {
            for (int k = 0; k < GENE_LENGTH; k++)
            {
                //0?99�̃����_���Ȓl���i�[
                int rnd = 0;
                rnd = UnityEngine.Random.Range(0, 99);

                //Mask�͖��񐶐�
                //��������ꍇ
                if (rnd < 50)
                {
                    program[i, k] = tmp_program[i + 1, k];
                    program[i + 1, k] = tmp_program[i, k];
                }

                //�������Ȃ��ꍇ
                else
                {
                    program[i, k] = tmp_program[i, k];
                    program[i + 1, k] = tmp_program[i + 1, k];
                }
            }
        }
    }

    //�ˑR�ψ�
    public void Mutation()
    {
        //0?99�̃����_���Ȓl���i�[
        int rnd = 0;

        //8�̖ڂ̓G���[�g�ɂȂ邽�ߕψقȂ�
        for (int i = 0; i < PROGRAM_NUMBER - 1; i++)
        {
            //�ˑR�ψٗ��ɉ����ĕψق��邩����
            rnd = UnityEngine.Random.Range(0, 99);

            if (rnd < MUTATION_PROBABILITY)
            {
                //�ψق����`�q������
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

            //�^�O���d�������Ƃ��i����Input,Output,���m�j�͋����I�ɕψ�+�{�^���^�O���d�������Ƃ�
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

        //�ˑR�ψٗ��ɉ����Ċe��`�q�������_���Ȓl�ɕύX
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

            //�^�O���d�������Ƃ��i����Input,Output,���m�j�͋����I�ɕψ�+�{�^���^�O���d�������Ƃ�
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
    // ������
    now_generation = 0;                                  //���݂̐���
    now_program_number = 0;                              //���݂̌�
    one_program = new int[GENE_LENGTH];                  //�\���p�i1�̕ۑ��j
    elite_program = new int[GENE_LENGTH];                //�G���[�g�ۑ�
    program = new int[PROGRAM_NUMBER, GENE_LENGTH];      //��`�q�z��
    tmp_program = new int[PROGRAM_NUMBER, GENE_LENGTH];  //��`�q�z��i�\�[�g�Ǝ��̐���p�j
    back_program = new int[PROGRAM_NUMBER, GENE_LENGTH]; //��`�q�z��i�߂�p�j
    evaluation = new int[GENERATION, PROGRAM_NUMBER];    //���ゲ�Ƃ̕]���l���i�[
}

}


 
 
 
 
 
 */