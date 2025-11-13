// using Api.Database;
// using Api.Database.Models;
// using Api.DTO;
// using Microsoft.EntityFrameworkCore;
//
// namespace Api.DAL;
//
// public class ChannelRepository : DatabaseRepository<Channel> {
//     private GlobalSettings _globalSettings;
//
//     public ChannelRepository(AppDbContext context, GlobalSettings globalSettings) :
//         base(context) {
//         _globalSettings = globalSettings;
//     }
//
//     public async Task<ValidationResult<ICollection<Channel>>> GetByPosition(
//         Position position) {
//         try {
//             var channels = _entity
//                            .Where(c => c.Center.DistanceTo(position) <= c.Radius)
//                                   .OrderBy(c => c.Center.DistanceTo(position));
//
//             return new(await channels.ToListAsync());
//         } catch (Exception ex) { return new ValidationResult<ICollection<Channel>>(ex); }
//     }
//
//     public override async Task<ValidationResult<Channel>> Add(IAddDto<Channel> dto) {
//         try {
//             var res = await base.Add(dto);
//             if (!res) return res;
//             res.Value!.Setting = new ChannelSetting {
//                 Id = res.Value.Id
//               , Channel = res.Value
//               , MessageArchiveThreshold = _globalSettings.Curator.DefaultMessageArchiveThreshold
//               , MessageDuration
//                     = TimeSpan.FromHours(_globalSettings.Curator.DefaultMessageDurationInHour)
//               , MessageHighlightThreshold = _globalSettings.Curator
//                                                      .DefaultMessageHighlightThreshold
//             };
//
//             _entity.Update(res.Value);
//             await _context.SaveChangesAsync();
//
//             return res;
//         } catch (Exception e) { return new(e); }
//     }
//
//     public override async Task<ValidationResult<Channel>> Add(Channel entity) {
//         try {
//             var res = await base.Add(entity);
//             if (!res) return res;
//             res.Value!.Setting = new ChannelSetting {
//                 Id = res.Value.Id
//               , Channel = res.Value
//               , MessageArchiveThreshold = _globalSettings.Curator.DefaultMessageArchiveThreshold
//               , MessageDuration
//                     = TimeSpan.FromHours(_globalSettings.Curator.DefaultMessageDurationInHour)
//               , MessageHighlightThreshold = _globalSettings.Curator
//                                                      .DefaultMessageHighlightThreshold
//             };
//
//             _entity.Update(res.Value);
//             await _context.SaveChangesAsync();
//
//             return res;
//         } catch (Exception e) { return new(e); }
//     }
//
//     public async Task<ValidationResult<ChannelSetting>> GetSetting(string id) {
//         try { return await GetSetting(Guid.Parse(id)); } catch (Exception ex) {
//             return new(ex);
//         }
//     }
//
//     public async Task<ValidationResult<ChannelSetting>> GetSetting(Guid id) {
//         try {
//             var channel = await Find(id);
//             if (channel == null) throw new Exception("Channel not found.");
//
//             await Load(channel, e => e.Setting);
//             return new ValidationResult<ChannelSetting>(channel.Setting);
//         } catch (Exception ex) { return new(ex); }
//     }
//
//     public async Task<ValidationResult<ChannelSetting>> UpdateSetting(
//         ChannelSettingsDto channelSetting) {
//         try {
//             var setting = (await GetSetting(channelSetting.Id)).ThrowIfInvalid().Value!;
//
//             channelSetting.Map(setting);
//             _context.ChannelSettings.Update(setting);
//             await _context.SaveChangesAsync();
//             return new(setting);
//         } catch (Exception ex) { return new(ex); }
//     }
// }