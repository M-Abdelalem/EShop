using Dapper;
using Discount.ApI.Entities;
using Discount.ApI.IRepository;
using System.Data;

namespace Discount.ApI.Repository
{
    public class DiscountRepository : RepositoryBase, IDiscountRepository
    {
        public IDbConnection _connection;
        public DiscountRepository(IDbConnection connection):base(connection)
        {
            _connection = connection;
        }
        public async Task<bool> delete(string productName)
        {
            try
            {
                var query = "delete from public.\"Coupon\" where \"ProductName\"=@ProductName";
                await _connection.ExecuteAsync(query, new
                {
                    ProductName = productName,
                }
                    );
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<Coupon> getDiscount(string productName)
        {
            try
            {
                Coupon Coupon = await _connection.QueryFirstOrDefaultAsync<Coupon>
                    ("SELECT c.* FROM   public.\"Coupon\" c where c.\"ProductName\" = @productName", new { productName = productName },
                      commandType: CommandType.Text);
                return Coupon;
            }catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> insert(Coupon coupon)
        {
            try
            {
                var query = "INSERT INTO public.\"Coupon\"(  \"ProductName\", \"Description\",\"Amount\") " +
                    "VALUES(@ProductName, @Description, @Amount)";
                await _connection.ExecuteAsync(query, new
                {
                    ProductName = coupon.ProductName,
                    Description = coupon.Description,
                    Amount = coupon.Amount
                }
                    );
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<bool> update(Coupon coupon)
        {

                try
                {
                    var query = "update  public.\"Coupon\" " +
                    "set \"ProductName\"=@ProductName ,\"Description\"=@Description,\"Amount\"=@Amount" +
                    " where \"ProductName\"=@ProductName";
                    await _connection.ExecuteAsync(query, new
                    {
                        ProductName = coupon.ProductName,
                        Description = coupon.Description,
                        Amount = coupon.Amount
                    }
                        );
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
    }
}
