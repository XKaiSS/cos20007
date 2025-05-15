namespace Swin_Adventure{

public class Bag : Item, IHaveInventory{
    private Inventory _inventory;
    
    public Bag(string[] idents, string name, string description): base(idents, name, description){
        _inventory = new Inventory();
    }

    public GameObject Locate(string id){
        if(AreYou(id)){
            return this;
        }
        else if (_inventory.HasItem(id)){
            return _inventory.Fetch(id);
        }
        else{
            return null;
        }
    }
    public Inventory Inventory{
        get{
            return _inventory;
        }
    }

    public override string FullDescription{
        get { return "In the "+ Name +" you can see:\n " + Inventory.ItemList; }
    }

      //=====Verification task=======

    public int LocateItemInPlayer(Player player, string itemId){
        if (player.Inventory.HasItem(itemId)){
            return 1;
        }
        foreach ( Item item in player.Inventory.Items)
        {
            if (item is Bag bag)
               if(bag.Inventory.HasItem(itemId)){
                return 2;  
            }
            
        }
        return 3;
    }


}
}