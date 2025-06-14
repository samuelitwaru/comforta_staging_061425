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
   public class prc_updatepage : GXProcedure
   {
      public prc_updatepage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_updatepage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref Guid aP0_PageId ,
                           ref string aP1_PageName ,
                           ref string aP2_PageJsonContent ,
                           ref string aP3_PageGJSHtml ,
                           ref string aP4_PageGJSJson ,
                           ref bool aP5_PageIsPublished ,
                           ref bool aP6_IsNotifyResidents ,
                           out string aP7_Response ,
                           out SdtSDT_Error aP8_Error )
      {
         this.AV8PageId = aP0_PageId;
         this.AV18PageName = aP1_PageName;
         this.AV12PageJsonContent = aP2_PageJsonContent;
         this.AV13PageGJSHtml = aP3_PageGJSHtml;
         this.AV11PageGJSJson = aP4_PageGJSJson;
         this.AV17PageIsPublished = aP5_PageIsPublished;
         this.AV22IsNotifyResidents = aP6_IsNotifyResidents;
         this.AV10Response = "" ;
         this.AV27Error = new SdtSDT_Error(context) ;
         initialize();
         ExecuteImpl();
         aP0_PageId=this.AV8PageId;
         aP1_PageName=this.AV18PageName;
         aP2_PageJsonContent=this.AV12PageJsonContent;
         aP3_PageGJSHtml=this.AV13PageGJSHtml;
         aP4_PageGJSJson=this.AV11PageGJSJson;
         aP5_PageIsPublished=this.AV17PageIsPublished;
         aP6_IsNotifyResidents=this.AV22IsNotifyResidents;
         aP7_Response=this.AV10Response;
         aP8_Error=this.AV27Error;
      }

      public SdtSDT_Error executeUdp( ref Guid aP0_PageId ,
                                      ref string aP1_PageName ,
                                      ref string aP2_PageJsonContent ,
                                      ref string aP3_PageGJSHtml ,
                                      ref string aP4_PageGJSJson ,
                                      ref bool aP5_PageIsPublished ,
                                      ref bool aP6_IsNotifyResidents ,
                                      out string aP7_Response )
      {
         execute(ref aP0_PageId, ref aP1_PageName, ref aP2_PageJsonContent, ref aP3_PageGJSHtml, ref aP4_PageGJSJson, ref aP5_PageIsPublished, ref aP6_IsNotifyResidents, out aP7_Response, out aP8_Error);
         return AV27Error ;
      }

      public void executeSubmit( ref Guid aP0_PageId ,
                                 ref string aP1_PageName ,
                                 ref string aP2_PageJsonContent ,
                                 ref string aP3_PageGJSHtml ,
                                 ref string aP4_PageGJSJson ,
                                 ref bool aP5_PageIsPublished ,
                                 ref bool aP6_IsNotifyResidents ,
                                 out string aP7_Response ,
                                 out SdtSDT_Error aP8_Error )
      {
         this.AV8PageId = aP0_PageId;
         this.AV18PageName = aP1_PageName;
         this.AV12PageJsonContent = aP2_PageJsonContent;
         this.AV13PageGJSHtml = aP3_PageGJSHtml;
         this.AV11PageGJSJson = aP4_PageGJSJson;
         this.AV17PageIsPublished = aP5_PageIsPublished;
         this.AV22IsNotifyResidents = aP6_IsNotifyResidents;
         this.AV10Response = "" ;
         this.AV27Error = new SdtSDT_Error(context) ;
         SubmitImpl();
         aP0_PageId=this.AV8PageId;
         aP1_PageName=this.AV18PageName;
         aP2_PageJsonContent=this.AV12PageJsonContent;
         aP3_PageGJSHtml=this.AV13PageGJSHtml;
         aP4_PageGJSJson=this.AV11PageGJSJson;
         aP5_PageIsPublished=this.AV17PageIsPublished;
         aP6_IsNotifyResidents=this.AV22IsNotifyResidents;
         aP7_Response=this.AV10Response;
         aP8_Error=this.AV27Error;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new prc_isauthenticated(context).executeUdp( ) )
         {
            AV27Error.gxTpr_Status = context.GetMessage( "Error", "");
            AV27Error.gxTpr_Message = context.GetMessage( "Not Authenticated", "");
         }
         else
         {
            AV9BC_Trn_Page.Load(AV8PageId, new prc_getuserlocationid(context).executeUdp( ));
            if ( ! (Guid.Empty==AV9BC_Trn_Page.gxTpr_Trn_pageid) )
            {
               AV9BC_Trn_Page.gxTpr_Trn_pagename = AV18PageName;
               AV9BC_Trn_Page.gxTpr_Pagegjsjson = AV11PageGJSJson;
               if ( AV9BC_Trn_Page.gxTpr_Pageisdynamicform || AV9BC_Trn_Page.gxTpr_Pageisweblinkpage )
               {
                  AV9BC_Trn_Page.gxTpr_Pagegjsjson = "";
               }
               if ( AV17PageIsPublished )
               {
                  AV9BC_Trn_Page.gxTpr_Pagejsoncontent = AV12PageJsonContent;
                  AV9BC_Trn_Page.gxTpr_Pageispublished = AV17PageIsPublished;
               }
               AV9BC_Trn_Page.gxTpr_Pagegjshtml = AV13PageGJSHtml;
               AV9BC_Trn_Page.Save();
               if ( AV9BC_Trn_Page.Success() )
               {
                  AV10Response = context.GetMessage( "Page Save Successfully", "");
                  context.CommitDataStores("prc_updatepage",pr_default);
                  if ( AV22IsNotifyResidents )
                  {
                     AV24Title = context.GetMessage( "New Updates Available", "");
                     AV25NotificationMessage = context.GetMessage( "The latest updates have been published and are now live! Open the app to explore the changes", "");
                     AV23Metadata = new SdtSDT_OneSignalCustomData(context);
                     AV23Metadata.gxTpr_Notificationcategory = "Toolbox";
                  }
               }
               else
               {
                  AV30GXV2 = 1;
                  AV29GXV1 = AV9BC_Trn_Page.GetMessages();
                  while ( AV30GXV2 <= AV29GXV1.Count )
                  {
                     AV14Message = ((GeneXus.Utils.SdtMessages_Message)AV29GXV1.Item(AV30GXV2));
                     new prc_logtofile(context ).execute(  AV14Message.gxTpr_Description) ;
                     AV30GXV2 = (int)(AV30GXV2+1);
                  }
               }
            }
            else
            {
               AV10Response = context.GetMessage( "Page Not Found", "");
            }
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
         AV10Response = "";
         AV27Error = new SdtSDT_Error(context);
         AV9BC_Trn_Page = new SdtTrn_Page(context);
         AV24Title = "";
         AV25NotificationMessage = "";
         AV23Metadata = new SdtSDT_OneSignalCustomData(context);
         AV29GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV14Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.prc_updatepage__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.prc_updatepage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prc_updatepage__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV30GXV2 ;
      private bool AV17PageIsPublished ;
      private bool AV22IsNotifyResidents ;
      private string AV12PageJsonContent ;
      private string AV13PageGJSHtml ;
      private string AV11PageGJSJson ;
      private string AV10Response ;
      private string AV18PageName ;
      private string AV24Title ;
      private string AV25NotificationMessage ;
      private Guid AV8PageId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Guid aP0_PageId ;
      private string aP1_PageName ;
      private string aP2_PageJsonContent ;
      private string aP3_PageGJSHtml ;
      private string aP4_PageGJSJson ;
      private bool aP5_PageIsPublished ;
      private bool aP6_IsNotifyResidents ;
      private SdtSDT_Error AV27Error ;
      private SdtTrn_Page AV9BC_Trn_Page ;
      private IDataStoreProvider pr_default ;
      private SdtSDT_OneSignalCustomData AV23Metadata ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV29GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV14Message ;
      private string aP7_Response ;
      private SdtSDT_Error aP8_Error ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class prc_updatepage__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class prc_updatepage__gam : DataStoreHelperBase, IDataStoreHelper
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

public class prc_updatepage__default : DataStoreHelperBase, IDataStoreHelper
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
