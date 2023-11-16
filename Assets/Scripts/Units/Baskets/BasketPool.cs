using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BasketPool : MonoBehaviour
{
    private List<Basket> _baskets = new List<Basket>();
    [SerializeField] private Basket basketPrefab;
    [SerializeField] private Basket perforatedBasketPrefab;
    [SerializeField] private int initialPoolSize = 3;
    [SerializeField] private int lineSpacing = 3;
    private Transform _t;
    public static BasketPool Instance;
    float startPositionY = 0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _t = transform;
        InitialObjectPool();
        SpawnBasketsInLine();
    }

    private void InitialObjectPool()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            Basket basket = Instantiate(basketPrefab, _t);
            Basket perforatedBasket = Instantiate(perforatedBasketPrefab, _t);
            _baskets.Add(basket);
            _baskets.Add(perforatedBasket);
        }

        _baskets = _baskets.OrderBy(x => Random.value).ToList();
    }

    public void SpawnBasketsInLine()
    {
        for (int i = 0; i < 5;)
        {
            Basket pooledBasket = GetPooledBasket();
            if (pooledBasket != null)
            {
                pooledBasket.transform.position = new Vector3(_t.position.x, startPositionY, _t.position.z);
                startPositionY += lineSpacing; // Update the position for the next basket
                i++;
            }
        }
    }

    public Basket GetPooledBasket()
    {
        foreach (Basket basket in _baskets)
        {
            if (!basket.gameObject.activeSelf)
            {
                basket.gameObject.SetActive(true);
                return basket;
            }
        }

        return null;
    }

    public void PoolBasket(Basket basket)
    {
        basket.gameObject.SetActive(false);
    }
}
