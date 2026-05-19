const form = document.querySelector("#booking-form");
const total = document.querySelector("#total");
const details = document.querySelector("#details");
const checkin = document.querySelector("#checkin");
const checkout = document.querySelector("#checkout");

const today = new Date();
const tomorrow = new Date(today);
tomorrow.setDate(today.getDate() + 1);

checkin.valueAsDate = today;
checkout.valueAsDate = tomorrow;

const currency = new Intl.NumberFormat("pt-BR", {
  style: "currency",
  currency: "BRL"
});

form.addEventListener("submit", (event) => {
  event.preventDefault();

  const adults = Number(document.querySelector("#adults").value);
  const children = Number(document.querySelector("#children").value);
  const room = document.querySelector("#room");
  const dailyRate = Number(room.value);
  const start = new Date(`${checkin.value}T00:00:00`);
  const end = new Date(`${checkout.value}T00:00:00`);
  const nights = Math.ceil((end - start) / 86400000);

  if (!Number.isFinite(nights) || nights <= 0) {
    total.textContent = currency.format(0);
    details.textContent = "O check-out precisa ser posterior ao check-in.";
    return;
  }

  const guestFee = Math.max(0, adults + children - 2) * 35;
  const amount = (dailyRate + guestFee) * nights;
  const roomName = room.options[room.selectedIndex].text.split(" - ")[0];

  total.textContent = currency.format(amount);
  details.textContent = `${roomName}, ${nights} diaria(s), ${adults} adulto(s) e ${children} crianca(s).`;
});
