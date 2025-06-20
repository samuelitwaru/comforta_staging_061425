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
   public class prc_cleaninfocontent : GXProcedure
   {
      public prc_cleaninfocontent( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_cleaninfocontent( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref SdtSDT_InfoContent aP0_SDT_InfoContent )
      {
         this.AV8SDT_InfoContent = aP0_SDT_InfoContent;
         initialize();
         ExecuteImpl();
         aP0_SDT_InfoContent=this.AV8SDT_InfoContent;
      }

      public SdtSDT_InfoContent executeUdp( )
      {
         execute(ref aP0_SDT_InfoContent);
         return AV8SDT_InfoContent ;
      }

      public void executeSubmit( ref SdtSDT_InfoContent aP0_SDT_InfoContent )
      {
         this.AV8SDT_InfoContent = aP0_SDT_InfoContent;
         SubmitImpl();
         aP0_SDT_InfoContent=this.AV8SDT_InfoContent;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12GXV1 = 1;
         while ( AV12GXV1 <= AV11SDT_InfoPage.gxTpr_Infocontent.Count )
         {
            AV9InfoContent = ((SdtSDT_InfoPage_InfoContentItem)AV11SDT_InfoPage.gxTpr_Infocontent.Item(AV12GXV1));
            if ( StringUtil.StrCmp(AV9InfoContent.gxTpr_Infotype, "Cta") == 0 )
            {
            }
            else if ( StringUtil.StrCmp(AV9InfoContent.gxTpr_Infotype, "TileRow") == 0 )
            {
               AV13GXV2 = 1;
               while ( AV13GXV2 <= AV9InfoContent.gxTpr_Tiles.Count )
               {
                  AV10SDT_InfoTile = ((SdtSDT_InfoTile_SDT_InfoTileItem)AV9InfoContent.gxTpr_Tiles.Item(AV13GXV2));
                  if ( StringUtil.StrCmp(AV10SDT_InfoTile.gxTpr_Action.gxTpr_Objecttype, "DynamicForm") == 0 )
                  {
                     AV14GXLvl14 = 0;
                     /* Using cursor P00GT2 */
                     pr_default.execute(0, new Object[] {AV10SDT_InfoTile.gxTpr_Action.gxTpr_Formid, AV10SDT_InfoTile.gxTpr_Action.gxTpr_Objectid});
                     while ( (pr_default.getStatus(0) != 101) )
                     {
                        A206WWPFormId = P00GT2_A206WWPFormId[0];
                        A207WWPFormVersionNumber = P00GT2_A207WWPFormVersionNumber[0];
                        AV14GXLvl14 = 1;
                        pr_default.readNext(0);
                     }
                     pr_default.close(0);
                     if ( AV14GXLvl14 == 0 )
                     {
                        AV10SDT_InfoTile.gxTpr_Action.gxTpr_Objecttype = "";
                        AV10SDT_InfoTile.gxTpr_Action.gxTpr_Objectid = "";
                        AV10SDT_InfoTile.gxTpr_Action.gxTpr_Objecturl = "";
                        AV10SDT_InfoTile.gxTpr_Action.gxTpr_Formid = 0;
                     }
                  }
                  AV13GXV2 = (int)(AV13GXV2+1);
               }
            }
            else
            {
            }
            AV12GXV1 = (int)(AV12GXV1+1);
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
         AV11SDT_InfoPage = new SdtSDT_InfoPage(context);
         AV9InfoContent = new SdtSDT_InfoPage_InfoContentItem(context);
         AV10SDT_InfoTile = new SdtSDT_InfoTile_SDT_InfoTileItem(context);
         P00GT2_A206WWPFormId = new short[1] ;
         P00GT2_A207WWPFormVersionNumber = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_cleaninfocontent__default(),
            new Object[][] {
                new Object[] {
               P00GT2_A206WWPFormId, P00GT2_A207WWPFormVersionNumber
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV14GXLvl14 ;
      private short A206WWPFormId ;
      private short A207WWPFormVersionNumber ;
      private int AV12GXV1 ;
      private int AV13GXV2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSDT_InfoContent AV8SDT_InfoContent ;
      private SdtSDT_InfoContent aP0_SDT_InfoContent ;
      private SdtSDT_InfoPage AV11SDT_InfoPage ;
      private SdtSDT_InfoPage_InfoContentItem AV9InfoContent ;
      private SdtSDT_InfoTile_SDT_InfoTileItem AV10SDT_InfoTile ;
      private IDataStoreProvider pr_default ;
      private short[] P00GT2_A206WWPFormId ;
      private short[] P00GT2_A207WWPFormVersionNumber ;
   }

   public class prc_cleaninfocontent__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00GT2;
          prmP00GT2 = new Object[] {
          new ParDef("AV10SDT__2Action_2Formid",GXType.Int16,4,0) ,
          new ParDef("AV10SDT__1Action_1Objectid",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GT2", "SELECT WWPFormId, WWPFormVersionNumber FROM WWP_Form WHERE WWPFormId = :AV10SDT__2Action_2Formid or WWPFormId = TO_NUMBER(0 || :AV10SDT__1Action_1Objectid,'9999999999999999999999999999.99999999999999') ORDER BY WWPFormId, WWPFormVersionNumber ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GT2,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
