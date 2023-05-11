window.addEventListener('load', e => {
    // Header
    function subMenuArrow() {
        if (window.innerWidth < 916) {
            document.body.classList.add('_touch');
        
            let menuArrows = document.querySelectorAll('.menu__arrow');
            if (menuArrows.length > 0) {
                for (let index = 0; index < menuArrows.length; index++) {
                    const menuArrow = menuArrows[index];
                    menuArrow.addEventListener('click', function (e) {
                        menuArrow.parentElement.classList.toggle('_active');
                    });
                }
            }
        } else {
            document.body.classList.add('_pc');
        }
    }

    subMenuArrow()

    function burgerMenuShowHide() {
        let iconMenu = document.querySelector('.menu__icon')
        let body = document.body

        if (iconMenu) {
            iconMenu.addEventListener('click', function (e) {
                if(!iconMenu.classList.contains('_active'))
                    body.classList.add('_lock');
                else
                    body.classList.remove('_lock');

                iconMenu.classList.toggle('_active')
                document.querySelector('.menu__body').classList.toggle('_active');
            });
        }
    }

    burgerMenuShowHide()

    function setMinDate() {
        let datePicker = document.querySelector('.header__form-date');

        if (datePicker != null){
            let today = new Date();
            let dd = today.getDate();
            let mm = today.getMonth() + 1;
            let yyyy = today.getFullYear();

            if (dd < 10) {
                dd = '0' + dd;
            }

            if (mm < 10) {
                mm = '0' + mm;
            } 
                
            today = yyyy + '-' + mm + '-' + dd;
            datePicker.setAttribute("min", today);
        }
    }

    setMinDate()

    //Hero
    function changeImage() {
        let image = document.querySelector('.header__image')

        if (image != null) {
            window.onresize = e => {
                if(window.innerWidth < 680) {
                    image.innerHTML = '<img src="images/hero-image-small.jpg" alt="">'
                }
                if(window.innerWidth > 680) {
                    image.innerHTML = '<img src="images/hero-image.jpg" alt="">'
                }
            }
            if(window.innerWidth < 680) {
                image.innerHTML = '<img src="images/hero-image-small.jpg" alt="">'
            }
            if(window.innerWidth > 680) {
                image.innerHTML = '<img src="images/hero-image.jpg" alt="">'
            }
        }
        else {
            let header = document.querySelector('.header__wrap')

            if(header != null) {
                document.querySelector('.menu__icon').style.top = '0'
                header.style.backgroundColor = '#0097B2'
                document.querySelector('.header__logo img').style.width = '90px'
            }
        }
    }

    changeImage()

    // Tickets

    function showSortingOptions() {
        let button = document.querySelector('.tickets-content__title-sortby-button-button')

        if (button) {
            let sortingMenu = $('.tickets-content__sort-options')

            button.addEventListener('click', e => {
                if(button.classList.contains('active')) {
                    sortingMenu.hide(150)
                    button.classList.remove('active')
                }
                else {
                    sortingMenu.show(150)
                    button.classList.add('active')
                }
            })
        }
    }

    showSortingOptions()

    function rotateArrowBack(outerButton) {
        document.querySelectorAll('.tickets-content__sort-options-button .fa-chevron-down').forEach(arrow => {
            arrow.style.transform = 'rotate(0deg)'
        })

        document.querySelectorAll('.tickets-content__sort-options-button').forEach(button => {
            if(button.classList != outerButton.classList){
                if (button.classList.contains('asc')) {
                    button.classList.remove('asc')
                }
                else {
                    button.classList.remove('desc')
                }
            }
        })
    }

    function sortByTime(button, exactTime) {
        if (button != null) {
            let arrow = button.querySelector('.fa-chevron-down')
            arrow.style.transition = 'transform 0.2s ease-out'

            button.addEventListener('click', e => {

                if(button.classList.contains('asc')) {

                    button.classList.replace('asc', 'desc')
                    rotateArrowBack(button)
                    arrow.style.transform = 'rotate(0deg)'
                    timeSorting(false, exactTime)
                }

                else if(button.classList.contains('desc')) {

                    button.classList.replace('desc', 'asc')
                    rotateArrowBack(button)
                    arrow.style.transform = 'rotate(180deg)'
                    timeSorting(true, exactTime)
                }

                else if( !(button.classList.contains('asc') || button.classList.contains('desc')) ) {
                    button.classList.add('asc')
                    rotateArrowBack(button)
                    arrow.style.transform = 'rotate(180deg)'
                    timeSorting(true, exactTime)
                }

            })
        }
    }

    function timeSorting(asc, exactTime) {
        let tickets = document.querySelectorAll('.tickets-content__tickets-ticket')
  
        Array.from(tickets).sort(function(a, b) {
            let timeArrA = a.querySelector(exactTime).innerHTML.replace(/[^0-9,:]/g,"").split(':')
            a = ~~timeArrA[0] * 60 + ~~timeArrA[1]

            let timeArrB = b.querySelector(exactTime).innerHTML.replace(/[^0-9,:]/g,"").split(':')
            b = ~~timeArrB[0] * 60 + ~~timeArrB[1]

            if (asc)
                return a - b
            else
                return b - a    

        }).forEach(function(n, i) {
            n.style.order = i
        })
    }

    function sortByDepartureTime() {
        let button = document.querySelector('.departure-time')
        let exactTime = '.tickets-content__tickets-ticket-when-from_time-time'
        sortByTime(button, exactTime)
    }

    sortByDepartureTime()

    function sortByArriveTime() {
        let button = document.querySelector('.arrive-time')
        let exactTime = '.tickets-content__tickets-ticket-when-to_time-time'
        sortByTime(button, exactTime)
    }

    sortByArriveTime()


    function travelTimeSorting(asc) {
        let tickets = document.querySelectorAll('.tickets-content__tickets-ticket')

        Array.from(tickets).sort(function(a, b) {
            let timeArrA = a.querySelector('.tickets-content__tickets-ticket-when-time_in_trip-time').innerHTML.replace(/[^0-9, ]/g,"").trim().split(' ')
            a = ~~timeArrA[0] * 60 + ~~timeArrA[1]

            let timeArrB = b.querySelector('.tickets-content__tickets-ticket-when-time_in_trip-time').innerHTML.replace(/[^0-9, ]/g,"").trim().split(' ')
            b = ~~timeArrB[0] * 60 + ~~timeArrB[1]

            if (asc)
                return a - b
            else
                return b - a    

        }).forEach(function(n, i) {
            n.style.order = i
        })
    }

    function sortByTravelTime() {
        let button = document.querySelector('.travel-time')

        if (button != null) {
            let arrow = button.querySelector('.fa-chevron-down')
            arrow.style.transition = 'transform 0.2s ease-out'

            button.addEventListener('click', e => {

                if(button.classList.contains('asc')) {

                    button.classList.replace('asc', 'desc')
                    rotateArrowBack(button)
                    arrow.style.transform = 'rotate(0deg)'
                    travelTimeSorting(false)
                }

                else if(button.classList.contains('desc')) {
                    
                    button.classList.replace('desc', 'asc')
                    rotateArrowBack(button)
                    arrow.style.transform = 'rotate(180deg)'
                    travelTimeSorting(true)
                }

                else if( !(button.classList.contains('asc') || button.classList.contains('desc')) ) {
                    button.classList.add('asc')
                    rotateArrowBack(button)
                    arrow.style.transform = 'rotate(180deg)'
                    travelTimeSorting(true)
                }

            })
        }
    }

    sortByTravelTime()

    function priceSorting(asc) {
        let tickets = document.querySelectorAll('.tickets-content__tickets-ticket')

        Array.from(tickets).sort(function(a, b) {
            a = ~~(a.querySelector('.tickets-content__tickets-ticket-buy-price').innerHTML.replace(/[^0-9,.]/g,""))

            b = ~~(b.querySelector('.tickets-content__tickets-ticket-buy-price').innerHTML.replace(/[^0-9,.]/g,""))

            if (asc)
                return a - b
            else
                return b - a    

        }).forEach(function(n, i) {
            n.style.order = i
        })
    }

    function sortByPrice() {
        let button = document.querySelector('.price')

        if (button != null) {
            let arrow = button.querySelector('.fa-chevron-down')
            arrow.style.transition = 'transform 0.2s ease-out'

            button.addEventListener('click', e => {
                if(button.classList.contains('asc')) {

                    button.classList.replace('asc', 'desc')
                    rotateArrowBack(button)
                    arrow.style.transform = 'rotate(0deg)'
                    priceSorting(false)
                }

                else if(button.classList.contains('desc')) {

                    button.classList.replace('desc', 'asc')
                    rotateArrowBack(button)
                    arrow.style.transform = 'rotate(180deg)'
                    priceSorting(true)
                }

                else if( !(button.classList.contains('asc') || button.classList.contains('desc')) ) {
                    button.classList.add('asc')
                    rotateArrowBack(button)
                    arrow.style.transform = 'rotate(180deg)'
                    priceSorting(true)
                }

            })
        }
    }

    sortByPrice()

    function ticketsLeftSorting(asc) {
        let tickets = document.querySelectorAll('.tickets-content__tickets-ticket')

        Array.from(tickets).sort(function(a, b) {
            a = ~~(a.querySelector('.tickets-content__tickets-ticket-buy-form-tickets_left').innerHTML.replace(/[^0-9]/g,""))

            b = ~~(b.querySelector('.tickets-content__tickets-ticket-buy-form-tickets_left').innerHTML.replace(/[^0-9]/g,""))

            if (asc)
                return a - b
            else
                return b - a    

        }).forEach(function(n, i) {
            n.style.order = i
        })
    }

    function sortByTicketsLeft() {
        let button = document.querySelector('.tickets-left')

        if (button != null) {
            let arrow = button.querySelector('.fa-chevron-down')
            arrow.style.transition = 'transform 0.2s ease-out'

            button.addEventListener('click', e => {
                if(button.classList.contains('asc')) {

                    button.classList.replace('asc', 'desc')
                    rotateArrowBack(button)
                    arrow.style.transform = 'rotate(0deg)'
                    ticketsLeftSorting(false)
                }

                else if(button.classList.contains('desc')) {

                    button.classList.replace('desc', 'asc')
                    rotateArrowBack(button)
                    arrow.style.transform = 'rotate(180deg)'
                    ticketsLeftSorting(true)
                }

                else if( !(button.classList.contains('asc') || button.classList.contains('desc')) ) {
                    button.classList.add('asc')
                    rotateArrowBack(button)
                    arrow.style.transform = 'rotate(180deg)'
                    ticketsLeftSorting(true)
                }

            })
        }
    }

    sortByTicketsLeft()
     
    // Buy page

    function subtractValue() {
        let subtractBtnTickets = document.querySelector('.ticket_buy__form-tickets_count-content-counter-subtract')
        let subtractBtnBaggage = document.querySelector('.ticket_buy__form-additional_baggage-add-options-option-add-subtract_add-subtract')
    
        if (subtractBtnTickets != null && subtractBtnBaggage != null) {
            let inputTickets = document.querySelector('.ticket_buy__form-tickets_count-content-counter-value input')
            let inputBaggage = document.querySelector('.ticket_buy__form-additional_baggage-add-options-option-add-subtract_add-value input')

            subtractBtnBaggage.addEventListener('click', e => {
                inputBaggage.stepDown()
                if(~~inputBaggage.getAttribute('value') > 0) {
                    inputBaggage.setAttribute('value', inputBaggage.getAttribute('value') - 1)
                }
            })

            subtractBtnTickets.addEventListener('click', e => {
                inputTickets.stepDown()
                if(~~inputTickets.getAttribute('value') > 1) {
                    inputTickets.setAttribute('value', inputTickets.getAttribute('value') - 1)
                }
            })
        }
    }

    subtractValue()

    function addValue() {
        let addBtnTickets = document.querySelector('.ticket_buy__form-tickets_count-content-counter-add')
        let addBtnBaggage = document.querySelector('.ticket_buy__form-additional_baggage-add-options-option-add-subtract_add-add')
    
        if (addBtnTickets != null && addBtnBaggage != null) {
            let inputTickets = document.querySelector('.ticket_buy__form-tickets_count-content-counter-value input')
            let inputBaggage = document.querySelector('.ticket_buy__form-additional_baggage-add-options-option-add-subtract_add-value input')

            addBtnBaggage.addEventListener('click', e => {
                inputBaggage.stepUp()
                inputBaggage.setAttribute('value', ~~inputBaggage.getAttribute('value') + 1)
            })

            addBtnTickets.addEventListener('click', e => {
                inputTickets.stepUp()
                inputTickets.setAttribute('value', ~~inputTickets.getAttribute('value') + 1)
            })
        }
    }

    addValue()

    function showHideBaggageOptions() {
        let btn = $('.ticket_buy__form-additional_baggage-add-header')
        
        if (btn != null) {
            let optionsMenu = $('.ticket_buy__form-additional_baggage-add-options')
            let arrow = $('.ticket_buy__form-additional_baggage-add-header-arrow_icon i')

            btn.on('click', e => {
                if (optionsMenu.css('display') == 'none') {
                    btn.css('border-radius', '10px 10px 0 0')
                    arrow.css('transform', 'rotate(180deg)')
                    optionsMenu.show(150)
                }
                else if(optionsMenu.css('display') == 'block') {
                    btn.css('border-radius', '10px')
                    arrow.css('transform', 'rotate(0deg)')
                    optionsMenu.hide(150)
                }
            })
        }
    }

    showHideBaggageOptions()
})