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
namespace GeneXus.Programs {
   public class prc_registerresidentlanguage : GXProcedure
   {
      public prc_registerresidentlanguage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_registerresidentlanguage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UserId ,
                           string aP1_Language ,
                           out string aP2_Message )
      {
         this.AV14UserId = aP0_UserId;
         this.AV18Language = aP1_Language;
         this.AV11Message = "" ;
         initialize();
         ExecuteImpl();
         aP2_Message=this.AV11Message;
      }

      public string executeUdp( string aP0_UserId ,
                                string aP1_Language )
      {
         execute(aP0_UserId, aP1_Language, out aP2_Message);
         return AV11Message ;
      }

      public void executeSubmit( string aP0_UserId ,
                                 string aP1_Language ,
                                 out string aP2_Message )
      {
         this.AV14UserId = aP0_UserId;
         this.AV18Language = aP1_Language;
         this.AV11Message = "" ;
         SubmitImpl();
         aP2_Message=this.AV11Message;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18Language)) )
         {
            AV24GXLvl4 = 0;
            /* Optimized UPDATE. */
            /* Using cursor P00D72 */
            pr_default.execute(0, new Object[] {AV18Language, AV14UserId});
            if ( (pr_default.getStatus(0) != 101) )
            {
               AV24GXLvl4 = 1;
            }
            pr_default.close(0);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Resident");
            /* End optimized UPDATE. */
            if ( AV24GXLvl4 == 0 )
            {
               AV23isNotFound = true;
            }
            if ( AV23isNotFound )
            {
               AV11Message = context.GetMessage( "User not found", "");
            }
            else
            {
               new prc_logtofile(context ).execute(  context.GetMessage( "Labguage : ", "")+AV18Language) ;
               context.CommitDataStores("prc_registerresidentlanguage",pr_default);
               AV11Message = context.GetMessage( "Language preference updated.", "");
            }
         }
         else
         {
            AV11Message = context.GetMessage( "Language preference not provided.", "");
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("prc_registerresidentlanguage",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV11Message = "";
         A599ResidentLanguage = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_registerresidentlanguage__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_registerresidentlanguage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_registerresidentlanguage__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV24GXLvl4 ;
      private string AV18Language ;
      private string A599ResidentLanguage ;
      private bool AV23isNotFound ;
      private string AV11Message ;
      private string AV14UserId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string aP2_Message ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_registerresidentlanguage__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_registerresidentlanguage__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_registerresidentlanguage__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new UpdateCursor(def[0])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmP00D72;
       prmP00D72 = new Object[] {
       new ParDef("ResidentLanguage",GXType.Char,20,0) ,
       new ParDef("AV14UserId",GXType.VarChar,100,60)
       };
       def= new CursorDef[] {
           new CursorDef("P00D72", "UPDATE Trn_Resident SET ResidentLanguage=:ResidentLanguage  WHERE ResidentGUID = ( :AV14UserId)", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00D72)
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
