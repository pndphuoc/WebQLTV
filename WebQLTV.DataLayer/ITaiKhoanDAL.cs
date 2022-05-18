using QuanLyThuVIen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebQLTV.DataLayer
{
    public interface ITaiKhoanDAL
    {

        /// <summary>
        /// Kiem tra dang nhap
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
       DocGia CheckLogin(string email, string password);



        /// <summary>
        /// Doi mat khau
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool ChangePass(string email, string password);


        /// <summary>
        /// Lay thong tin cua doc gia bang ma doc gia
        /// </summary>
        /// <param name="madocgia"></param>
        /// <returns></returns>
        DocGia GetDocGia(string username);
    }
}
