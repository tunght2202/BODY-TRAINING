using AutoMapper;
using BODYTRANINGAPI.Models;
using BODYTRANINGAPI.ViewModels;

namespace BODYTRANINGAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddExerciseViewModel, Exercise>();
            CreateMap<ExerciseMediaViewModel, ExerciseMedia>();
            CreateMap<AddExerciseViewModel, Exercise>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.DifficultyLevel, opt => opt.MapFrom(src => src.DifficultyLevel))
            //.ForMember(dest => dest.Access, opt => opt.MapFrom(src => src.Access))
           // .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted))
            .ReverseMap();
            CreateMap<AddExerciseViewModel, Exercise>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.DifficultyLevel, opt => opt.MapFrom(src => src.DifficultyLevel))
            //.ForMember(dest => dest.Access, opt => opt.MapFrom(src => src.Access))
           // .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted))
            .ReverseMap();
            CreateMap<Muscle, CreateMuscleViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ReverseMap();
        }


    }

}
