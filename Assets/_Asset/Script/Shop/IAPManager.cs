using GooglePlayGames;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour, IStoreListener
{
    private IStoreController storeController;
    private IExtensionProvider extensionProvider;

    // ID của sản phẩm, như đã cấu hình trên Unity Dashboard
    [SerializeField] public string[] productID;
    [SerializeField] public ProductType[] type;
    [SerializeField] private int amountcoin;
    [SerializeField] private SaveData savecoin;

    void Start()
    {
        InitializePurchasing();
    }

    public void InitializePurchasing()
    {
        if (IsInitialized())
        {
            return;
        }

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        // Thêm sản phẩm vào builder
        for (int i =0;i<productID.Length;i++)
        {
            builder.AddProduct(productID[i], type[i]);
        }

        UnityPurchasing.Initialize(this, builder);
    }

    private bool IsInitialized()
    {
        return storeController != null && extensionProvider != null;
    }

    public void SetCoin(int amount)
    {
        amountcoin = amount;
    }

    public void BuyProduct(string id)
    {
        if (IsInitialized())
        {
            Product product = storeController.products.WithID(id);

            if (product != null && product.availableToPurchase)
            {
                Debug.Log($"Purchasing product asychronously: {product.definition.id}");
                storeController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        else
        {
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized: PASS");

        storeController = controller;
        extensionProvider = extensions;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log($"OnInitializeFailed InitializationFailureReason: {error}");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (args.purchasedProduct != null)
        {
            Debug.Log($"ProcessPurchase: PASS. Product: {args.purchasedProduct.definition.id}");
            savecoin.SaveCoinData("currentcoin", amountcoin);
            if(!PlayerPrefs.HasKey("FirstPurchase"))
            {
                if(Social.localUser.authenticated)
                {
                    PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_first_purchase,100.0f,(result)=>
                    { 
                        if (result)
                        {
                            Debug.Log("success");
                        }
                        else
                        {
                            Debug.Log("failed");
                        }
                    });
                    savecoin.Save("FirstPurchase", 1);
                }
            }
        }
        else
        {
            Debug.Log($"ProcessPurchase: FAIL. Unrecognized product: {args.purchasedProduct.definition.id}");
        }

        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log($"OnPurchaseFailed: FAIL. Product: {product.definition.storeSpecificId}, PurchaseFailureReason: {failureReason}");
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        throw new System.NotImplementedException();
    }
}
