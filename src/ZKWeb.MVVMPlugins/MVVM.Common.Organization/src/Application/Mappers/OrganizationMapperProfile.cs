﻿using AutoMapper;
using ZKWeb.MVVMPlugins.MVVM.Common.Organization.src.Application.Dtos;
using ZKWeb.MVVMPlugins.MVVM.Common.Organization.src.Domain.Entities;
using ZKWebStandard.Ioc;

namespace ZKWeb.MVVMPlugins.MVVM.Common.Organization.src.Application.Mappers {
	/// <summary>
	/// AutoMapper的配置
	/// </summary>
	[ExportMany]
	public class OrganizationMapperProfile : Profile {
		public OrganizationMapperProfile() {
			// 用户
			CreateMap<User, UserOutputDto>()
				.ForMember(d => d.OwnerTenantName, m => m.ResolveUsing(u => u.OwnerTenant?.Name));

			// 角色
			CreateMap<Role, RoleOutputDto>()
				.ForMember(d => d.Privileges, m => m.ResolveUsing(r => r.GetPrivileges()))
				.ForMember(d => d.OwnerTenantName, m => m.ResolveUsing(r => r.OwnerTenant?.Name));
		}
	}
}