using Api.DAL;

namespace Api.Services;

public class SupportTicketService {
    private LandmarkRepository _landmark;
    private SupportTicketRepository _supportTicket;

    public SupportTicketService(LandmarkRepository landmark, SupportTicketRepository supportTicket) {
        _landmark = landmark;
        _supportTicket = supportTicket;
    }
    
    

    // public void SuggestLandmark(SuggestLandmarkDto dto) {
    //     
    // } //convert to a support ticket

}