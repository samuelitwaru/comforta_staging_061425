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
   public class prc_getmemocategories : GXProcedure
   {
      public prc_getmemocategories( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_getmemocategories( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDT_MemoCategory> aP0_SDT_MemoCategories )
      {
         this.AV9SDT_MemoCategories = new GXBaseCollection<SdtSDT_MemoCategory>( context, "SDT_MemoCategory", "Comforta_version21") ;
         initialize();
         ExecuteImpl();
         aP0_SDT_MemoCategories=this.AV9SDT_MemoCategories;
      }

      public GXBaseCollection<SdtSDT_MemoCategory> executeUdp( )
      {
         execute(out aP0_SDT_MemoCategories);
         return AV9SDT_MemoCategories ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDT_MemoCategory> aP0_SDT_MemoCategories )
      {
         this.AV9SDT_MemoCategories = new GXBaseCollection<SdtSDT_MemoCategory>( context, "SDT_MemoCategory", "Comforta_version21") ;
         SubmitImpl();
         aP0_SDT_MemoCategories=this.AV9SDT_MemoCategories;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00CS2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A542MemoCategoryId = P00CS2_A542MemoCategoryId[0];
            A543MemoCategoryName = P00CS2_A543MemoCategoryName[0];
            AV10SDT_MemoCategory = new SdtSDT_MemoCategory(context);
            AV10SDT_MemoCategory.gxTpr_Memocategoryid = A542MemoCategoryId;
            AV10SDT_MemoCategory.gxTpr_Memocategoryname = A543MemoCategoryName;
            AV9SDT_MemoCategories.Add(AV10SDT_MemoCategory, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV9SDT_MemoCategories = new GXBaseCollection<SdtSDT_MemoCategory>( context, "SDT_MemoCategory", "Comforta_version21");
         P00CS2_A542MemoCategoryId = new Guid[] {Guid.Empty} ;
         P00CS2_A543MemoCategoryName = new string[] {""} ;
         A542MemoCategoryId = Guid.Empty;
         A543MemoCategoryName = "";
         AV10SDT_MemoCategory = new SdtSDT_MemoCategory(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_getmemocategories__default(),
            new Object[][] {
                new Object[] {
               P00CS2_A542MemoCategoryId, P00CS2_A543MemoCategoryName
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string A543MemoCategoryName ;
      private Guid A542MemoCategoryId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDT_MemoCategory> AV9SDT_MemoCategories ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00CS2_A542MemoCategoryId ;
      private string[] P00CS2_A543MemoCategoryName ;
      private SdtSDT_MemoCategory AV10SDT_MemoCategory ;
      private GXBaseCollection<SdtSDT_MemoCategory> aP0_SDT_MemoCategories ;
   }

   public class prc_getmemocategories__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00CS2;
          prmP00CS2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00CS2", "SELECT MemoCategoryId, MemoCategoryName FROM Trn_MemoCategory ORDER BY MemoCategoryId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CS2,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
