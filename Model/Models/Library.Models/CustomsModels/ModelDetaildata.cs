using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.CustomsModels
{
    public class ModelDetaildata
    {
        /// <summary> 
        /// ���ݱ��� 
        /// </summary>
        [Required]
        [Display(Name = "���ݱ���")]
        public String Djbm { get;set;} 

        /// <summary> 
        /// ��Ʒ��� 
        /// </summary>
        [Required]
        [Display(Name = "��Ʒ���")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "��Ʒ����������")]
        public Int32 Spxh { get;set;} 

        /// <summary> 
        /// �������
    
        /// </summary>
        [Display(Name = "�������")]
        public String Baxh { get;set;} 

        /// <summary> 
        /// ��Ʒ��� 
        /// </summary>
        [Display(Name = "��Ʒ���")]
        public String Spbh { get;set;} 

        /// <summary> 
        /// ���ӱ�� 
        /// </summary>
        [Display(Name = "���ӱ��")]
        public String Fjbh { get;set;} 

        /// <summary> 
        /// ��Ʒ���� 
        /// </summary>
        [Display(Name = "��Ʒ����")]
        public String Spmc { get;set;} 

        /// <summary> 
        /// ����ͺ� 
        /// </summary>
        [Display(Name = "����ͺ�")]
        public String Ggxh { get;set;} 

        /// <summary> 
        /// �ɽ����� 
        /// </summary>
        [Display(Name = "�ɽ�����")]
        public Object Cjsl { get;set;} 

        /// <summary> 
        /// �ɽ���λ 
        /// </summary>
        [Display(Name = "�ɽ���λ")]
        public String Cjdw { get;set;} 

        /// <summary> 
        /// �ɽ����� 
        /// </summary>
        [Display(Name = "�ɽ�����")]
        public Object Cjdj { get;set;} 

        /// <summary> 
        /// �ɽ��ܼ� 
        /// </summary>
        [Display(Name = "�ɽ��ܼ�")]
        public Object Cjzj { get;set;} 

        /// <summary> 
        /// ���� 
        /// </summary>
        [Display(Name = "����")]
        public String Bizhi { get;set;} 

        /// <summary> 
        /// �������� 
        /// </summary>
        [Display(Name = "��������")]
        public Object Fdsl { get;set;} 

        /// <summary> 
        /// ������λ 
        /// </summary>
        [Display(Name = "������λ")]
        public String Fddw { get;set;} 

        /// <summary> 
        /// �汾�� 
        /// </summary>
        [Display(Name = "�汾��")]
        public String Bbh { get;set;} 

        /// <summary> 
        /// ���� 
        /// </summary>
        [Display(Name = "����")]
        public String Huoh { get;set;} 

        /// <summary> 
        /// �������� 
        /// </summary>
        [Display(Name = "��������")]
        public String Sccj { get;set;} 

        /// <summary> 
        /// �ڶ�����
    
        /// </summary>
        [Display(Name = "�ڶ�����")]
        public Object Desl { get;set;} 

        /// <summary> 
        /// �ڶ���λ 
        /// </summary>
        [Display(Name = "�ڶ���λ")]
        public String Dedw { get;set;} 

        /// <summary> 
        /// Ŀ�ĵ� 
        /// </summary>
        [Display(Name = "Ŀ�ĵ�")]
        public String Mdd { get;set;} 

        /// <summary> 
        /// ���ص����� 
        /// </summary>
        [Display(Name = "���ص�����")]
        public String Zm { get;set;} 

        /// <summary> 
        /// ���ɷ�
    
        /// </summary>
        [Display(Name = "���ɷ�")]
        public Object Gjf { get;set;} 

        /// <summary> 
        /// ��; 
        /// </summary>
        [Display(Name = "��;")]
        public String Yt { get;set;} 

    }
}
