using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class prc_deleteorganisationform : GXProcedure
   {
      public prc_deleteorganisationform( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_deleteorganisationform( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( Guid aP0_OrganisationDynamicFormId ,
                           Guid aP1_OrganisationId ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_OutMessage )
      {
         this.A509OrganisationDynamicFormId = aP0_OrganisationDynamicFormId;
         this.A11OrganisationId = aP1_OrganisationId;
         this.AV8OutMessage = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         ExecuteImpl();
         aP2_OutMessage=this.AV8OutMessage;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( Guid aP0_OrganisationDynamicFormId ,
                                                                             Guid aP1_OrganisationId )
      {
         execute(aP0_OrganisationDynamicFormId, aP1_OrganisationId, out aP2_OutMessage);
         return AV8OutMessage ;
      }

      public void executeSubmit( Guid aP0_OrganisationDynamicFormId ,
                                 Guid aP1_OrganisationId ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_OutMessage )
      {
         this.A509OrganisationDynamicFormId = aP0_OrganisationDynamicFormId;
         this.A11OrganisationId = aP1_OrganisationId;
         this.AV8OutMessage = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         SubmitImpl();
         aP2_OutMessage=this.AV8OutMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9Trn_OrganisationDynamicForm.Load(A509OrganisationDynamicFormId, A11OrganisationId);
         AV9Trn_OrganisationDynamicForm.Delete();
         if ( AV9Trn_OrganisationDynamicForm.Success() )
         {
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_deleteform(context ).execute(  AV9Trn_OrganisationDynamicForm.gxTpr_Wwpformid,  AV9Trn_OrganisationDynamicForm.gxTpr_Wwpformversionnumber, out  AV8OutMessage) ;
         }
         else
         {
            AV8OutMessage = AV9Trn_OrganisationDynamicForm.GetMessages();
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
         AV8OutMessage = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV9Trn_OrganisationDynamicForm = new SdtTrn_OrganisationDynamicForm(context);
         /* GeneXus formulas. */
      }

      private Guid A509OrganisationDynamicFormId ;
      private Guid A11OrganisationId ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV8OutMessage ;
      private SdtTrn_OrganisationDynamicForm AV9Trn_OrganisationDynamicForm ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_OutMessage ;
   }

}
