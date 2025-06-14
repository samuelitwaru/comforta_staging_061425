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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prc_creategamuseraccountnocommit : GXProcedure
   {
      public prc_creategamuseraccountnocommit( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prc_creategamuseraccountnocommit( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Email ,
                           string aP1_GivenName ,
                           string aP2_LastName ,
                           string aP3_RoleName ,
                           ref string aP4_GAMUserGUID ,
                           ref GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP5_GAMErrorCollection ,
                           ref bool aP6_isSuccessful )
      {
         this.AV12Email = aP0_Email;
         this.AV17GivenName = aP1_GivenName;
         this.AV20LastName = aP2_LastName;
         this.AV11RoleName = aP3_RoleName;
         this.AV9GAMUserGUID = aP4_GAMUserGUID;
         this.AV14GAMErrorCollection = aP5_GAMErrorCollection;
         this.AV19isSuccessful = aP6_isSuccessful;
         initialize();
         ExecuteImpl();
         aP4_GAMUserGUID=this.AV9GAMUserGUID;
         aP5_GAMErrorCollection=this.AV14GAMErrorCollection;
         aP6_isSuccessful=this.AV19isSuccessful;
      }

      public bool executeUdp( string aP0_Email ,
                              string aP1_GivenName ,
                              string aP2_LastName ,
                              string aP3_RoleName ,
                              ref string aP4_GAMUserGUID ,
                              ref GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP5_GAMErrorCollection )
      {
         execute(aP0_Email, aP1_GivenName, aP2_LastName, aP3_RoleName, ref aP4_GAMUserGUID, ref aP5_GAMErrorCollection, ref aP6_isSuccessful);
         return AV19isSuccessful ;
      }

      public void executeSubmit( string aP0_Email ,
                                 string aP1_GivenName ,
                                 string aP2_LastName ,
                                 string aP3_RoleName ,
                                 ref string aP4_GAMUserGUID ,
                                 ref GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP5_GAMErrorCollection ,
                                 ref bool aP6_isSuccessful )
      {
         this.AV12Email = aP0_Email;
         this.AV17GivenName = aP1_GivenName;
         this.AV20LastName = aP2_LastName;
         this.AV11RoleName = aP3_RoleName;
         this.AV9GAMUserGUID = aP4_GAMUserGUID;
         this.AV14GAMErrorCollection = aP5_GAMErrorCollection;
         this.AV19isSuccessful = aP6_isSuccessful;
         SubmitImpl();
         aP4_GAMUserGUID=this.AV9GAMUserGUID;
         aP5_GAMErrorCollection=this.AV14GAMErrorCollection;
         aP6_isSuccessful=this.AV19isSuccessful;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV16GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV16GAMUser.gxTpr_Guid = AV9GAMUserGUID;
         AV16GAMUser.gxTpr_Name = AV12Email;
         AV16GAMUser.gxTpr_Firstname = AV17GivenName;
         AV16GAMUser.gxTpr_Lastname = AV20LastName;
         AV16GAMUser.gxTpr_Email = AV12Email;
         AV16GAMUser.gxTpr_Password = Guid.NewGuid( ).ToString();
         AV16GAMUser.gxTpr_Authenticationtypename = "local";
         AV16GAMUser.gxTpr_Namespace = "Comforta";
         AV16GAMUser.save();
         if ( AV16GAMUser.success() )
         {
            AV24ActivationKey = AV16GAMUser.getnewactivationkey(out  AV25GAMErrors);
            AV23Role = AV15GAMRole.getbyname(AV11RoleName, out  AV14GAMErrorCollection);
            if ( AV16GAMUser.addrole(AV23Role, out  AV14GAMErrorCollection) )
            {
               new prc_senduseractivationlinknocommit(context ).execute(  AV9GAMUserGUID,  AV24ActivationKey,  AV10HttpRequest.BaseURL, ref  AV19isSuccessful, ref  AV13ErrDescription, ref  AV14GAMErrorCollection) ;
               if ( AV19isSuccessful )
               {
                  AV9GAMUserGUID = AV16GAMUser.gxTpr_Guid;
               }
               else
               {
                  if ( AV14GAMErrorCollection.Count > 0 )
                  {
                     AV8GAMErrorItem = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
                     AV8GAMErrorItem.gxTpr_Code = 462;
                     AV8GAMErrorItem.gxTpr_Message = context.GetMessage( "Activation error - ", "")+AV13ErrDescription;
                     AV14GAMErrorCollection.Add(AV8GAMErrorItem, 0);
                  }
               }
            }
            else
            {
               AV19isSuccessful = false;
            }
         }
         else
         {
            AV8GAMErrorItem = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
            AV8GAMErrorItem.gxTpr_Code = 161;
            AV8GAMErrorItem.gxTpr_Message = context.GetMessage( "Failed to save user - ", "")+((GeneXus.Programs.genexussecurity.SdtGAMError)AV16GAMUser.geterrors().Item(1)).gxTpr_Message;
            AV14GAMErrorCollection.Add(AV8GAMErrorItem, 0);
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
         AV16GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV24ActivationKey = "";
         AV25GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV23Role = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV15GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV10HttpRequest = new GxHttpRequest( context);
         AV13ErrDescription = "";
         AV8GAMErrorItem = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         /* GeneXus formulas. */
      }

      private string AV24ActivationKey ;
      private string AV13ErrDescription ;
      private bool AV19isSuccessful ;
      private string AV12Email ;
      private string AV17GivenName ;
      private string AV20LastName ;
      private string AV11RoleName ;
      private string AV9GAMUserGUID ;
      private GxHttpRequest AV10HttpRequest ;
      private string aP4_GAMUserGUID ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV14GAMErrorCollection ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> aP5_GAMErrorCollection ;
      private bool aP6_isSuccessful ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV16GAMUser ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV25GAMErrors ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV23Role ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV15GAMRole ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV8GAMErrorItem ;
   }

}
