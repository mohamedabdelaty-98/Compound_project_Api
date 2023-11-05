using BussienesLayer.DTO.ReviewDTO;
using DataAccessLayer.Reposatories.ReviewReposatory;

namespace Compound_project.Reposatories.ReviewReposatory
{
   public interface IReviewOperationsReposatory
   {
      Task<ReviewCreateReturn> Create(ReviewDTO reviewDTO);
      Task<bool> Delete(int id, IReviewReposatory _ReviewReposatory);
      Task<bool> Update(int id, ReviewDTO reviewDTO, IReviewReposatory _ReviewReposatory);
   }
}