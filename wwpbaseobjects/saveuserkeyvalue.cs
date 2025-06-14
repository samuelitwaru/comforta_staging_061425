using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects {
   public class saveuserkeyvalue : GXProcedure
   {
      public saveuserkeyvalue( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public saveuserkeyvalue( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserCustomizationsKey ,
                           string aP1_UserCustomizationsValue )
      {
         this.AV23UserCustomizationsKey = aP0_UserCustomizationsKey;
         this.AV24UserCustomizationsValue = aP1_UserCustomizationsValue;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_UserCustomizationsKey ,
                                 string aP1_UserCustomizationsValue )
      {
         this.AV23UserCustomizationsKey = aP0_UserCustomizationsKey;
         this.AV24UserCustomizationsValue = aP1_UserCustomizationsValue;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24UserCustomizationsValue)) )
         {
            AV22Session.Remove(AV23UserCustomizationsKey);
         }
         else
         {
            AV22Session.Set(AV23UserCustomizationsKey, AV24UserCustomizationsValue);
         }
         AV25UserCustomizations.Load(new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid(), AV23UserCustomizationsKey);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24UserCustomizationsValue)) )
         {
            if ( AV25UserCustomizations.Success() )
            {
               AV25UserCustomizations.Delete();
               context.CommitDataStores("wwpbaseobjects.saveuserkeyvalue",pr_default);
            }
         }
         else
         {
            if ( ! AV25UserCustomizations.Success() )
            {
               AV25UserCustomizations = new GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations(context);
               AV25UserCustomizations.gxTpr_Usercustomizationsid = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
               AV25UserCustomizations.gxTpr_Usercustomizationskey = AV23UserCustomizationsKey;
            }
            AV25UserCustomizations.gxTpr_Usercustomizationsvalue = AV24UserCustomizationsValue;
            AV25UserCustomizations.Save();
            context.CommitDataStores("wwpbaseobjects.saveuserkeyvalue",pr_default);
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV22Session = context.GetSession();
         AV25UserCustomizations = new GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.saveuserkeyvalue__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private string AV24UserCustomizationsValue ;
      private string AV23UserCustomizationsKey ;
      private IGxSession AV22Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations AV25UserCustomizations ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class saveuserkeyvalue__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class saveuserkeyvalue__gam : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

  public override string getDataStoreName( )
  {
     return "GAM";
  }

}

public class saveuserkeyvalue__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       def= new CursorDef[] {
       };
    }
 }

 public void getResults( int cursor ,
                         IFieldGetter rslt ,
                         Object[] buf )
 {
 }

}

}
