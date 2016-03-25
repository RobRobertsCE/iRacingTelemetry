using SetupParameterLibrary.Data;
using SetupParameterLibrary.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SetupParameterLibrary
{
    public static class SetupParameterHandler
    {
        // Groups
        public static IList<SetupGroup> GetGroups()
        {
            using (var context = new SetupDbContext())
            {
                return context.Groups.Include("SubGroups").Include("SubGroups.Parameters").AsEnumerable().Select(g => new SetupGroup(g)).ToList();
            }
        }
        public static SetupGroup GetGroup(Guid id)
        {
            using (var context = new SetupDbContext())
            {
                var model = context.Groups.FirstOrDefault(g => g.SetupGroupId == id);
                return new SetupGroup(model);
            }
        }
        public static SetupGroup SaveGroup(SetupGroup group)
        {
            using (var context = new SetupDbContext())
            {
                var model = group.ToModel();
                if (model.SetupGroupId == Guid.Empty)
                {
                    context.Groups.Add(model);
                }
                else
                {
                    context.Groups.Attach(model);
                    context.Entry(model).State = EntityState.Modified;
                }
                context.SaveChanges();
                var newModel = context.Groups.FirstOrDefault(g => g.Name == group.Name);
                return new SetupGroup(newModel);
            }
        }
        public static void DeleteGroup(Guid id)
        {
            using (var context = new SetupDbContext())
            {
                var model = context.Groups.FirstOrDefault(g => g.SetupGroupId == id);
                context.Groups.Remove(model);
                context.SaveChanges();
            }
        }

        // SubGroups
        public static IList<SetupSubGroup> GetSubGroups()
        {
            using (var context = new SetupDbContext())
            {
                return context.SubGroups.AsEnumerable().Select(s => new SetupSubGroup(s)).ToList();
            }
        }
        public static SetupSubGroup GetSubGroup(Guid id)
        {
            using (var context = new SetupDbContext())
            {
                var model = context.SubGroups.FirstOrDefault(g => g.SetupSubGroupId == id);
                return new SetupSubGroup(model);
            }
        }
        public static SetupSubGroup SaveSubGroup(SetupSubGroup subGroup)
        {
            using (var context = new SetupDbContext())
            {
                var model = subGroup.ToModel();
                if (model.SetupSubGroupId == Guid.Empty)
                {
                    context.SubGroups.Add(model);
                }
                else
                {
                    context.SubGroups.Attach(model);
                    context.Entry(model).State = EntityState.Modified;
                }
                context.SaveChanges();
                var newModel = context.SubGroups.FirstOrDefault(s => s.SetupSubGroupId == subGroup.SetupSubGroupId);
                return new SetupSubGroup(newModel);
            }
        }
        public static void DeleteSubGroup(Guid id)
        {
            using (var context = new SetupDbContext())
            {
                var model = context.SubGroups.FirstOrDefault(s => s.SetupSubGroupId == id);
                context.SubGroups.Remove(model);
                context.SaveChanges();
            }
        }

        // Parameters
        public static IList<SetupParameter> GetParameters()
        {
            using (var context = new SetupDbContext())
            {
                return context.Parameters.AsEnumerable().Select(p => new SetupParameter(p)).ToList();
            }
        }
        public static SetupParameter GetParameter(Guid id)
        {
            using (var context = new SetupDbContext())
            {
                var model = context.Parameters.FirstOrDefault(p => p.SetupParameterId == id);
                return new SetupParameter(model);
            }
        }      
        public static SetupParameter SaveParameter(SetupParameter parameter)
        {
            using (var context = new SetupDbContext())
            {
                var model = parameter.ToModel();
                if (model.SetupParameterId == Guid.Empty)
                {
                    context.Parameters.Add(model);
                }
                else
                {
                    context.Parameters.Attach(model);
                    context.Entry(model).State = EntityState.Modified;
                }
                context.SaveChanges();
                var newModel = context.Parameters.FirstOrDefault(p => p.SetupParameterId == parameter.SetupParameterId);
                return new SetupParameter(newModel);
            }
        }
        public static void DeleteParameter(Guid id)
        {
            using (var context = new SetupDbContext())
            {
                var model = context.Parameters.FirstOrDefault(p => p.SetupParameterId == id);
                context.Parameters.Remove(model);
                context.SaveChanges();
            }
        }
    }
}
