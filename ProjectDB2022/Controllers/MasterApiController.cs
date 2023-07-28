using DatabaseOperationServices.Implementaion;
using DatabaseOperationServices.Interface;
using Microsoft.Ajax.Utilities;
using ProjectDatabaseOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectDB2022.BL;
using System.IO;
using System.Web;
using Newtonsoft.Json;
using Microsoft.Owin.BuilderProperties;
using Microsoft.SqlServer.Server;
using System.Reflection;
using System.Web.Helpers;
using System.Xml.Linq;


namespace ProjectDB2022.Controllers
{
    public class MasterApiController : ApiController
    {

        
        ExtraBL ebl;

        ITopicService _opicService;
        ITopicContentService _opicContentService;
        IPostcategorieService _postcategorieService;
        IStateService _stateService;
        ICityService _cityService;
        ILocationService _locationService;
        IQualificationService _qualificationService;
        ISpecilizationService _specilizationService;
        IRoleService _roleService;
        IGenderService _genderService;
        IDesignationService _designationService;

        

         IUserDetailService _userDetailService;
        //IUserQualificationService _userQualificationService;
        // IUserExpertise _ex;

        IUserProfessionalExperinceService _userProfessionalService;
        public MasterApiController(ITopicService opicService, ITopicContentService opicContentService, IPostcategorieService postcategorieService, IStateService stateService, ICityService cityService, ILocationService locationService, IQualificationService qualificationService, ISpecilizationService specilizationService, IRoleService roleService, IGenderService genderService, IDesignationService designationService, IUserDetailService userDetailService, IUserQualificationService userQualificationService, IUserExpertise ex, IUserProfessionalExperinceService userProfessionalService)
        {

            ebl = new ExtraBL();
            _opicService = opicService;
            _opicContentService = opicContentService;
            _postcategorieService = postcategorieService;
            _stateService = stateService;
            _cityService = cityService;
            _locationService = locationService;
            _qualificationService = qualificationService;
            _specilizationService = specilizationService;
            _roleService = roleService;
            _genderService = genderService;
            _designationService = designationService;
            _userDetailService = userDetailService;
            //_userQualificationService = userQualificationService;
            //_ex = ex;
            _userProfessionalService = userProfessionalService;
        }


        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
      
        [HttpPost]
        [Route("api/master/userdetails")]
        public string Adduserdetails()
        {
            // ebl.getPhoto(file); 

            var form = HttpContext.Current.Request.Form;
            HttpPostedFile imageFile = HttpContext.Current.Request.Files["user_photo"];


            sp_fetch_tbluser_details_Result userdetails = new sp_fetch_tbluser_details_Result
            {
                gender_id = int.Parse(form["gender_id"]),
                location_id = int.Parse(form["location_id"]),
                role_id = int.Parse(form["role_id"]),
                first_name = form["first_name"],
                middle_name = form["middle_name"],
                last_name = form["last_name"],
                local_address = form["local_address"],
                birth_date = DateTime.Parse(form["Birth_date"]),
                mobile_number = form["mobile_number"],
                email_address= form["email_address"],
                user_name = form["user_name"],
                is_permium = int.Parse(form["premium"]),
               joining_date = DateTime.Parse(form["Birth_date"])
               

            };

           
            if (imageFile.ContentLength > 0)
            {
              string imgname = userdetails.first_name + Path.GetExtension(imageFile.FileName);
              string filePath = HttpContext.Current.Server.MapPath("~/Images/" + imgname);
                imageFile.SaveAs(filePath);
               userdetails.user_photo = filePath;
            }


           userdetails.password = ebl.GeneratePassword(8);
            string msg = "<h2>Dear " + userdetails.first_name + "</h2>,<p> Your account has been creted successfully.</p><p>You can access your account by following credentials.</p><p>Employee Code:<b>" + userdetails.user_name + "</b><br/>Password:<b>" + userdetails.password + "</b><br/></p><p><br/><br/><br/><br/><br/><h4>Thanks & Regards</h4><h4></h4></p>";
           string subject = "Employee Account registration";
            ExtraBL.Send_Email(userdetails.email_address, subject, msg);
           _userDetailService.AddUserDetailService(userdetails);
            return "User Registered Successfull";
        }

        [HttpGet]
        [Route("api/master/userdetails")]
        public List<sp_fetch_tbluser_details_Result> Showuserdetails()
        {
            return _userDetailService.GetUserDetailServices();
        }

        // change premimum
        [HttpPost]
        [Route("api/master/changePremium")]
        public string Change_Premium(sp_fetch_tbluser_details_Result userdetails)
        {
            _userDetailService.ChangePremium(userdetails);
            return "change premium";
        }

        ///// Api Qualification ///
        [HttpGet]
        [Route("api/master/qualification")]
        public List<sp_fetch_qualifications_Result> GetAll()
        {
            return _qualificationService.GetQualificatonServices();
        }

        [HttpPost]
        [Route("api/master/qualification/{id}")]
        public sp_fetch_qualifications_Result GetAll(int id)
        {
            return _qualificationService.GetQualificatonService(id);
        }

        [HttpPost]
        [Route("api/master/qualification")]
        public string Addqualification(sp_fetch_qualifications_Result s)
        {
            _qualificationService.AddQualificatonService(s);
            return "data added successfully";

        }

        [HttpDelete]
        [Route("api/master/qualification/{id}")]
        public string Deletequalification(int id)
        {
            _qualificationService.DeleteQualificatonService(id);
            return "data delete successfully";
        }


        [HttpDelete]
        [Route("api/master/qualification/{id}")]
        public string Restorequalification(int id)
        {

            return "done";
        }


        [HttpPut]
        [Route("api/master/qualification")]
        public string UpdateQulafication(sp_fetch_qualifications_Result s)
        {
            _qualificationService.UpdateQualificatonService(s);
            return "data Update successfully";
        }

        /// api city  ///
        [HttpPost]
        [Route("api/master/city")]
        public string Addcity(sp_fetch_tblCities_Result city)
        {
            _cityService.AddCity(city);
            return "city Added";
        }

        [HttpGet]
        [Route("api/master/city")]
        public List<sp_fetch_tblCities_Result> Showcity()
        {
            return _cityService.GetCitys();

        }

        [HttpGet]
        [Route("api/master/city/{id}")]
        public sp_fetch_tblCities_Result Showcity(int id)
        {
            return _cityService.GetCity(id);
        }

        [HttpPut]
        [Route("api/master/city")]
        public string Update(sp_fetch_tblCities_Result city)
        {
            _cityService.UpdateCity(city);
            return "Update successfully";
        }

        [HttpDelete]
        [Route("api/master/city/{id}")]
        public string Deletecity(int id)
        {

            _cityService.DeleteCity(id);
            return "delete city successfully";
        }


        /// api State ////////
        [HttpPost]
        [Route("api/master/state")]
        public string AddState(sp_fetch_tblstates_Result state)
        {
            _stateService.AddState(state);
            return "State Added";
        }

        [HttpGet]
        [Route("api/master/state")]
        public List<sp_fetch_tblstates_Result> ShowStates()
        {
            return _stateService.GetStates();

        }

        [HttpGet]
        [Route("api/master/state/{id}")]
        public sp_fetch_tblstates_Result ShowStates(int id)
        {
            return _stateService.GetState(id);

        }

        [HttpPut]
        [Route("api/master/state")]
        public string Update(sp_fetch_tblstates_Result state)
        {
            _stateService.UpdateState(state);
            return "Update successfully";
        }

        [HttpDelete]
        [Route("api/master/state/{id}")]
        public string DeletaState(int id)
        {

            _stateService.DeleteState(id);
            return "delete state successfully";
        }


        /// Api Topic //
        /// 
        [HttpPost]
        [Route("api/master/topic")]
        public string Addtopic(sp_fetch_tbTopics_Result topic)
        {
            _opicService.AddTopic(topic);
            return "topic Added";
        }

        [HttpGet]
        [Route("api/master/topic")]
        public List<sp_fetch_tbTopics_Result> Showtopic()
        {
            return _opicService.GetTopics();

        }

        [HttpGet]
        [Route("api/master/topic/{id}")]
        public sp_fetch_tbTopics_Result Showtopic(int id)
        {
            return _opicService.GetTopic(id);

        }

        [HttpPut]
        [Route("api/master/topic")]
        public string Update(sp_fetch_tbTopics_Result topic)
        {
            _opicService.UpdateTopic(topic);
            return "Update successfully";
        }

        [HttpDelete]
        [Route("api/master/topic/{id}")]
        public string Deletetopic(int id)
        {

            _opicService.DeleteTopic(id);
            return "delete topic successfully";
        }


        //// Api TopicContent  //////
        ///
        [HttpPost]
        [Route("api/master/content")]
        public string Addtopicc(sp_fetch_tbTopic_Contents_Result topic)
        {
            // topicContentsServices.AddTopicContent(topic);
            _opicContentService.AddTopiccontent(topic);
            return "topic Added";
        }

        [HttpGet]
        [Route("api/master/content")]
        public List<sp_fetch_tbTopic_Contents_Result> Showtopicc()
        {
            return _opicContentService.GetTopiccontents();

        }

        [HttpGet]
        [Route("api/master/content/{id}")]
        public sp_fetch_tbTopic_Contents_Result Showtopicc(int id)
        {
            return _opicContentService.GetTopiccontent(id);

        }

        [HttpPut]
        [Route("api/master/content")]
        public string Updatec(sp_fetch_tbTopic_Contents_Result topic)
        {
            _opicContentService.UpdateTopiccontent(topic);
            return "Update successfully";
        }

        [HttpDelete]
        [Route("api/master/content/{id}")]
        public string Deletetopicc(int id)
        {

            _opicContentService.DeleteTopiccontent(id);
            return "delete topic successfully";
        }


        /// api post catagoires ..
        /// 
        [HttpPost]
        [Route("api/master/category")]
        public string Addcatagories(sp_fetch_tblpostcategories_Result catagories)
        {
            _postcategorieService.AddPostcategorie(catagories);
            return "catagories Added";
        }

        [HttpGet]
        [Route("api/master/category")]
        public List<sp_fetch_tblpostcategories_Result> Showcatagories()
        {
            return _postcategorieService.GetPostcategories();

        }

        [HttpGet]
        [Route("api/master/category/{id}")]
        public sp_fetch_tblpostcategories_Result Showcatagories(int id)
        {

            return _postcategorieService.GetPostcategorie(id);
        }

        [HttpPut]
        [Route("api/master/category")]
        public string Update(sp_fetch_tblpostcategories_Result catagories)
        {
            _postcategorieService.UpdatePostcategorie(catagories);
            return "Update successfully";
        }

        [HttpDelete]
        [Route("api/master/category/{id}")]
        public string Deletecatagories(int id)
        {

            _postcategorieService.DeletePostcategorie(id);
            return "delete catagories successfully";
        }


        // api location ///
        [HttpPost]
        [Route("api/master/location")]
        public string Addlocation(sp_fetch_tbllocation_Result location)
        {
            _locationService.AddLocation(location);
            return "location Added";
        }

        [HttpGet]
        [Route("api/master/location")]
        public List<sp_fetch_tbllocation_Result> Showlocation()
        {
            return _locationService.GetLocations();

        }

        [HttpGet]
        [Route("api/master/location/{id}")]
        public sp_fetch_tbllocation_Result Showlocation(int id)
        {
            return _locationService.GetLocation(id);

        }

        [HttpPut]
        [Route("api/master/location")]
        public string Update(sp_fetch_tbllocation_Result location)
        {

            _locationService.UpdateLocation(location);
            return "Update successfully";
        }

        [HttpDelete]
        [Route("api/master/location/{id}")]
        public string Deletelocation(int id)
        {

            _locationService.DeleteLocation(id);
            return "delete location successfully";
        }

        /// api specialization //
        /// 
        [HttpPost]
        [Route("api/master/specilization")]
        public string Addspecilization(sp_fetch_tblspecializations_Result specilization)
        {
            _specilizationService.AddSpecialization(specilization);
            return "specilization Added";
        }

        [HttpGet]
        [Route("api/master/specilization")]
        public List<sp_fetch_tblspecializations_Result> Showspecilization()
        {
            return _specilizationService.GetSpecializations();

        }

        [HttpGet]
        [Route("api/master/specilization/{id}")]
        public sp_fetch_tblspecializations_Result Showspecilization(int id)
        {
            return _specilizationService.GetSpecialization(id);

        }

        [HttpPut]
        [Route("api/master/specilization")]
        public string Update(sp_fetch_tblspecializations_Result specilization)
        {
            _specilizationService.UpdateSpecialization(specilization);
            return "Update successfully";
        }

        [HttpDelete]
        [Route("api/master/specilization/{id}")]
        public string Deletespecilization(int id)
        {

            _specilizationService.DeleteSpecialization(id);
            return "delete specilization successfully";
        }


        /// api role //
        /// 
        [HttpPost]
        [Route("api/master/rols")]
        public string Addrols(sp_fetch_tblroles_Result rols)
        {
            _roleService.AddRole(rols);
            return "rols Added";
        }

        [HttpGet]
        [Route("api/master/rols")]
        public List<sp_fetch_tblroles_Result> Showrols()
        {
            return _roleService.GetRoles();

        }

        [HttpGet]
        [Route("api/master/rols/{id}")]
        public sp_fetch_tblroles_Result Showrols(int id)
        {
            return _roleService.GetRole(id);

        }

        [HttpPut]
        [Route("api/master/rols")]
        public string Update(sp_fetch_tblroles_Result rols)
        {
            _roleService.UpdateRole(rols);
            return "Update successfully";
        }

        [HttpDelete]
        [Route("api/master/rols/{id}")]
        public string Deleterols(int id)
        {
            _roleService.DeleteRole(id);

            return "delete rols successfully";
        }


        /// api Gender ///
        /// 
        [HttpPost]
        [Route("api/master/gender")]
        public string Addgender(sp_fetch_tblGender_Result gender)
        {
            _genderService.AddGender(gender);
            return "gender Added";
        }

        [HttpGet]
        [Route("api/master/gender")]
        public List<sp_fetch_tblGender_Result> Showgender()
        {

            return _genderService.GetGenders();
        }

        [HttpGet]
        [Route("api/master/gender/{id}")]
        public sp_fetch_tblGender_Result Showgender(int id)
        {

            return _genderService.GetGender(id);
        }

        [HttpPut]
        [Route("api/master/gender")]
        public string Update(sp_fetch_tblGender_Result gender)
        {

            _genderService.UpdateGender(gender);
            return "Update successfully";
        }

        [HttpDelete]
        [Route("api/master/gender/{id}")]
        public string Deletegender(int id)
        {
            _genderService.DeleteGender(id);
            return "delete gender successfully";
        }

        //// api designation //////////
        ///
        [HttpPost]
        [Route("api/master/designation")]
        public string Adddesignation(sp_fetch_tbldesignations_Result designation)
        {
            _designationService.AddDesignation(designation);
            return "designation Added";
        }

        [HttpGet]
        [Route("api/master/designation")]
        public List<sp_fetch_tbldesignations_Result> Showdesignation()
        {
            return _designationService.GetDesignations();

        }

        [HttpGet]
        [Route("api/master/designation/{id}")]
        public sp_fetch_tbldesignations_Result Showdesignation(int id)
        {
            return _designationService.GetDesignation(id);

        }

        [HttpPut]
        [Route("api/master/designation")]
        public string Update(sp_fetch_tbldesignations_Result designation)
        {
            _designationService.UpdateDesignation(designation);
            return "Update successfully";
        }

        [HttpDelete]
        [Route("api/master/designation/{id}")]
        public string DeletaDesignation(int id)
        {

            _designationService.DeleteDesignation(id);
            return "delete state successfully";
        }

        //////////  api user details /////////////
        ///
    /*    [HttpPost]
        [Route("api/userdetails")]
        public string Adduserdetails(sp_fetch_tbluser_details_Result userdetails)
        {
            userdetails.password = ebl.GeneratePassword(8);
            string msg = "<h2>Dear " + userdetails.first_name + "</h2>,<p> Your account has been creted successfully.</p><p>You can access your account by following credentials.</p><p>Employee Code:<b>" + userdetails.user_name + "</b><br/>Password:<b>" + userdetails.password + "</b><br/></p><p><br/><br/><br/><br/><br/><h4>Thanks & Regards</h4><h4></h4></p>";
            string subject = "Employee Account registration";
            ExtraBL.Send_Email(userdetails.email_address, subject, msg);
            _userDetailService.AddUserDetailService(userdetails);
            return "User Registered Successfull";
        }

        [HttpGet]
        [Route("api/userdetails")]
        public List<sp_fetch_tbluser_details_Result> Showuserdetails()
        {
            return _userDetailService.GetUserDetailServices();
        }

        [HttpGet]
        [Route("api/userdetailsid")]
        public sp_fetch_tbluser_details_Result Showuserdetail()
        {
            if (int.TryParse(user_id, out int userIdInt))
            {
                return _userDetailService.GetUserDetailService(userIdInt);
            }
            else
            {
                return null;
            }
        }

        [HttpPut]
        [Route("api/userdetails")]
        public string Update(sp_fetch_tbluser_details_Result userdetails)
        {
            _userDetailService.UpdateUserDetailService(userdetails);
            return "Update successfully";
        }

        [HttpDelete]
        [Route("api/userdetails/{id}")]
        public string Deleteuserdetails(int id)
        {

            _userDetailService.DeleteUserDetailService(id);
            return "delete userdetails successfully";
        }

        [HttpGet]
        [Route("api/getcode")]
        public sp_fetch_tbluser_details_Result Getcode()
        {
            return _userDetailService.GetCode();
        }

        //use details change primium

        [HttpPost]
        [Route("api/changePremium")]
        public string Change_Premium(sp_fetch_tbluser_details_Result userdetails)
        {
            _userDetailService.ChangePremium(userdetails);
            return "change premium";
        }
        //// user qualificationn services
        ///
        [HttpPost]
        [Route("api/userqualification")]
        public string Adduserqualification(sp_fetch_tbluser_qualifications_Result userqualification)
        {
            _userQualificationService.AddUserQualificatonService(userqualification);
            return "userqualification Added";
        }

        [HttpGet]
        [Route("api/userqualification")]
        public List<sp_fetch_tbluser_qualifications_Result> Showuserqualification()
        {
            return _userQualificationService.GetUserQualificatonServices();

        }

        [HttpGet]
        [Route("api/userqualification/{id}")]
        public sp_fetch_tbluser_qualifications_Result Showuserqualification(int id)
        {
            return _userQualificationService.GetUserQualificatonServiceById(id);

        }

        [HttpPut]
        [Route("api/userqualification")]
        public string Update(sp_fetch_tbluser_qualifications_Result userqualification)
        {
            _userQualificationService.UpdateUserQualificatonService(userqualification);
            return "Update successfully";
        }

        [HttpDelete]
        [Route("api/userqualification/{id}")]
        public string Deleteuserqualification(int id)
        {

            _userQualificationService.DeleteUserQualificatonService(id);
            return "delete userqualification successfully";
        }
  */
        /// api experience details ////
        /// 
        [HttpPost]
        [Route("api/experience")]
        public string Adduserexperience(sp_fetch_tblexperience_details_Result userqualification)
        {
            _userProfessionalService.AddUserProfessionalExperince(userqualification);
            return "userqualification Added";
        }

        [HttpGet]
        [Route("api/experience")]
        public List<sp_fetch_tblexperience_details_Result> Showuserexperience()
        {
            return _userProfessionalService.GetUserProfessionalExperinces();

        }

        [HttpGet]
        [Route("api/experience/{id}")]
        public sp_fetch_tblexperience_details_Result Showuserexperience(int id)
        {
            return _userProfessionalService.GetUserProfessionalExperince(id);

        }

        [HttpPut]
        [Route("api/experience")]
        public string Update(sp_fetch_tblexperience_details_Result userqualification)
        {

            _userProfessionalService.UpdateUserProfessionalExperince(userqualification);
            return "Update successfully";
        }

        [HttpDelete]
        [Route("api/experience/{id}")]
        public string Deleteexperience(int id)
        {

            _userProfessionalService.DeleteUserProfessionalExperince(id);
            return "delete userqualification successfully";
        }

        /// api expertise
        /// 
        /*
              [HttpPost]
              [Route("api/expertise")]
              public string Adduserexpertise(sp_fecth_tbluser_professional_expertise_Result userqualification)
              {
                  //_userProfessionalService.AddUserProfessionalExperince(userqualification);
                 // _userProfessionalService.AddUserProfessionalExperince(userqualification);
                 _ex.AddUserExpertise(userqualification);
                  return "userqualification Added";
              }

              [HttpGet]
              [Route("api/expertise")]
              public List<sp_fecth_tbluser_professional_expertise_Result> Showusereexpertise()
              {
                  return _ex.GetUserExpertise();

              }

              [HttpGet]
              [Route("api/expertise/{id}")]
              public sp_fecth_tbluser_professional_expertise_Result Showusereexpertise(int id)
              {
                  return _ex.GetUserExpertise(id);

              }

              [HttpPut]
              [Route("api/expertise")]
              public string Updateexpertise(sp_fecth_tbluser_professional_expertise_Result userqualification)
              {

                  _ex.UpdateUserExpertise(userqualification);
                  return "Update successfully";
              }

              [HttpDelete]
              [Route("api/expertise/{id}")]
              public string Deleteexpertise(int id)
              {

                  _ex.DeleteUserExpertise(id);
                  return "delete successfully";
              }

          }
          }
        */
    }
}
