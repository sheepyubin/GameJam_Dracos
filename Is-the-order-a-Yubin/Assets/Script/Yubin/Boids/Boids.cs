using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class Boids : MonoBehaviour
{
    // Boid ��ü�� ������
    public BoidsAgent boidPrefab;

    // Boid ��ü ����Ʈ
    List<BoidsAgent> agents = new List<BoidsAgent>();

    // Boid ��ü�� �ൿ�� �����ϴ� ��ũ���ͺ� ������Ʈ
    public BoidsBehavior behavior;

    // Boid ��ü�� ���� ����
    [Range(10, 10000)]
    public int numberOfBoid = 250;

    // Boid ��ü�� ���� �е� ����
    public float AgentDensity = 0.08f;

    // ���� ����
    public float spawnRadius = 10f;

    // Boid ��ü�� �̵� ���⿡ �������� �̵� ���
    [Range(1f, 100f)]
    public float driveFactor = 10f;

    // Boid ��ü�� �ִ� �̵� �ӵ�
    [Range(1f, 100f)]
    public float maxSpeed = 5f;

    // �ٸ� Boids ��ü�� �����ϴ� ����
    [Range(1f, 10f)]
    public float neighborRadius = 0.01f;

    // �ٸ� Boid ��ü ȸ�� �ݰ�
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    // ������ ����
    float squareMaxSpeed;
    float squareNeighborRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    private void Start()
    {

        // ���� �̸� ���
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        // ��ü ���� �� ����Ʈ�� �߰�
        for (int i = 0; i < numberOfBoid; i++)
        {
            Vector2 randomPosition = (Vector2)transform.position + Random.insideUnitCircle.normalized * Random.Range(0f, spawnRadius);
            BoidsAgent newAgent = Instantiate(boidPrefab, randomPosition, Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)), transform);
            newAgent.name = "Agent " + i;
            newAgent.Initalize(this);
            agents.Add(newAgent);
        }
    }
    private void Update()
    {
        // �� ��ü�� �ֺ��� Ȯ��
        foreach (BoidsAgent agent in agents)
        {
            List<Transform> context = GetNearbyObjects(agent);

            //agent.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(Color.white, Color.red, context.Count / 6f);

            // �ൿ ��� behavior.CalculateMove() �ż��� ���
            Vector2 move = behavior.CalculateMove(agent, context, this);
            move *= driveFactor;

            // �ӵ� ����
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }

            // �̵�
            agent.Move(move);
        }
    }

    // �ֺ� Boid ��ü���� ����Ʈ�� ��ȯ�ϴ� �޼���
    List<Transform> GetNearbyObjects(BoidsAgent agent)
    {
        List<Transform> context = new List<Transform>();

        // �ֺ��� �ִ� Boid ��ü ����
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);

        // �ڱ� �ڽ��� Collider�� ������ �ֺ� ��ü���� ����Ʈ�� �߰�
        foreach (Collider2D c in contextColliders)
        {
            if (c != agent.BoidCollider)
            {
                context.Add(c.transform);
            }
        }

        return context;
    }

    // ������ ���� ���� �׸���
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.7f, 0.5f, 0.7f, 1.0f);
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
