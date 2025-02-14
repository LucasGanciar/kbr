﻿using KBR.Domain.Entities;
using KBR.Domain.Infra.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace KBR.Payment.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentRepository paymentRepository;

        public PaymentsController(PaymentRepository repository)
        {
            paymentRepository = repository;
        }

        [HttpPost]
        public async ValueTask<ActionResult> Create([FromBody]Order order)
        {
            try
            {
                await paymentRepository.Pay(order);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
