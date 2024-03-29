﻿toastr.options = {
    hideDuration: 300,
    timeOut: 2500,
    positionClass: "toast-bottom-right",
    "closeButton": false,
    "debug": false,
    "newestOnTop": true,
    "progressBar": false,
    "preventDuplicates": false,
    "onclick": null,
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
}

$('.preloaderdiv').removeClass('d-none')

$(document).ready(function () {

    $('.preloaderdiv').addClass('d-none');
    $('#phoneno').focus();

    //#region game

    $(document).on('click', '.gametap', function () {
        $('.preloaderdiv').removeClass('d-none')
        $("#ifwon").addClass("d-none");

        $('.absolutuser').removeClass('moveright');
        $('.absolutcomp').removeClass('moveleft');

        let obj = {
            selected: $(this).attr("data-selected"),
            userScore: $('#user').html(),
            compScore: $('#comp').html()
        };

        let rock = `
                    <svg width="85" height="110" viewBox="0 0 85 120" fill="none"
                         xmlns="http://www.w3.org/2000/svg">
                        <path d="M30.6262 4.83856C31.8201 3.26794 33.3763 2.00936 35.1619 1.17018C36.9476 0.331 38.9098 -0.0638772 40.8811 0.0192188C42.8524 0.102315 44.7743 0.66092 46.483 1.64739C48.1917 2.63387 49.6364 4.01895 50.6939 5.68446C57.4621 1.33652 62.9612 2.01324 68.5957 7.98533C71.1591 6.60526 74.1154 6.13697 76.9798 6.65725C81.3876 7.4524 84.1964 10.32 84.6364 14.7864C84.8225 16.6558 84.924 18.5338 84.924 20.4117C84.924 33.7939 84.7463 47.1761 85.0002 60.5498C85.1778 69.6433 81.616 76.7235 74.8055 82.3911C74.3165 82.755 73.9253 83.2345 73.667 83.7865C73.4086 84.3386 73.2911 84.9461 73.325 85.5547C73.2235 95.7056 73.0543 105.899 72.8935 116.067C72.8512 118.934 71.836 120 68.9849 120C54.4841 120 39.9832 120 25.4824 120C22.5298 120 21.523 118.934 21.523 115.931C21.523 105.823 21.523 95.7225 21.4638 85.6224C21.397 84.4902 20.9768 83.4074 20.2624 82.5264C15.6262 76.6981 10.66 71.1152 6.25225 65.1262C2.06444 59.4163 -0.583609 53.0043 0.127051 45.6704C0.592364 40.7641 1.60758 35.9678 4.45022 31.8821C5.7531 30.0127 7.83432 28.6931 9.48407 27.0351C10.1443 26.4679 10.5967 25.6971 10.77 24.8442C10.9392 21.1561 10.8123 17.4595 10.9646 13.7713C11.1507 9.20343 12.7159 5.16001 17.0644 3.096C21.413 1.03199 25.8885 1.82713 29.924 4.53402C30.1017 4.65245 30.2539 4.78781 30.4316 4.89778C30.4654 4.88932 30.5501 4.84702 30.6262 4.83856ZM41.8275 53.3004C42.5467 53.9856 43.1051 54.5016 43.6465 54.9922C48.3673 59.6024 50.6177 65.1431 49.924 71.775C49.6691 75.5718 47.9673 79.1263 45.1693 81.7059C44.8819 81.9909 44.5386 82.2133 44.1611 82.3593C43.7836 82.5053 43.3799 82.5716 42.9755 82.5541C42.5711 82.5366 42.1747 82.4357 41.8112 82.2577C41.4476 82.0797 41.1249 81.8285 40.8631 81.5198C39.7463 80.2848 39.704 78.9821 40.9561 77.8401C45.0509 74.2365 45.9054 66.2428 41.4299 61.3196C38.8918 58.4858 35.5078 56.3034 32.4282 54.0025C31.481 53.4386 30.3912 53.1596 29.2895 53.1989C25.2455 53.1143 21.2015 53.1989 17.1575 53.1989C14.4925 53.1989 13.3842 52.353 13.3673 50.4243C13.3504 48.4957 14.4587 47.5906 17.0813 47.599C24.1203 47.599 31.1592 47.599 38.2319 47.599C40.4103 47.6651 42.5439 46.9723 44.2678 45.6391C45.9916 44.3059 47.1985 42.4152 47.682 40.2904C49.1118 34.9866 46.5822 31.5268 41.2269 31.4338H40.3808C31.6668 31.5015 22.9556 31.5691 14.2472 31.6368C13.2287 31.6512 12.2333 31.9421 11.3675 32.4785C10.5017 33.0149 9.79799 33.7766 9.33177 34.6821C6.6744 39.0627 5.45552 44.1654 5.84615 49.2739C6.16764 54.5354 8.58727 59.0695 11.7683 63.096C16.2353 68.7889 21.0746 74.1773 25.6262 79.828C26.5983 81.0512 27.1634 82.5479 27.2421 84.1083C27.3859 93.3117 27.3182 102.507 27.3182 111.71V114.053H67.0814C67.1321 113.351 67.1998 112.742 67.2083 112.133C67.369 102.727 67.589 93.3202 67.6397 83.9052C67.5985 82.8753 67.8227 81.852 68.2909 80.9336C68.759 80.0152 69.4554 79.2325 70.3132 78.6606C76.0915 74.245 79.4841 68.569 79.2726 60.9812C79.0864 54.214 79.2726 47.4468 79.2726 40.6795V38.5309C74.5517 39.8844 70.4485 39.4614 67.0983 35.9002C63.215 39.4783 58.638 39.6729 53.9511 38.8524C52.6228 46.0679 48.9426 50.9657 41.8191 53.3004H41.8275ZM52.4874 20.9023H52.3775C52.5297 23.956 52.572 27.0182 52.9105 30.0465C53.06 31.1408 53.6269 32.1349 54.4925 32.8211C58.4519 35.4603 64.281 32.5588 64.4502 27.8641C64.6025 23.3526 64.6025 18.827 64.4502 14.2873C64.3487 10.5653 61.7514 8.43365 57.902 8.61129C56.3656 8.74505 54.9406 9.46777 53.925 10.6282C52.9095 11.7886 52.3823 13.2969 52.4536 14.8372C52.4959 16.8673 52.479 18.9229 52.479 20.9023H52.4874ZM34.2895 25.8847H46.5061C46.5061 21.0799 46.7514 16.0129 46.4215 10.9883C46.21 7.83305 43.3335 5.76059 40.3555 5.76059C36.9206 5.76059 34.6533 7.4101 34.3741 11.0898C34.0103 15.8353 34.281 20.6147 34.281 25.8847H34.2895ZM28.122 25.5294C28.122 20.9446 28.2658 16.5797 28.0712 12.2233C27.9528 9.44026 25.9815 8.04453 22.4959 7.71463C19.7802 7.46086 18.0204 8.47594 17.2506 11.0982C15.8546 15.8353 16.7176 20.6823 16.4976 25.5294H28.122ZM79.1795 22.9917C79.1795 20.6993 79.2726 18.4069 79.1795 16.1145C79.0526 13.619 77.9189 12.4263 75.7277 12.1387C73.1896 11.8173 71.7091 12.6885 70.9562 15.1078C70.5521 16.2919 70.324 17.5288 70.2793 18.779C70.2793 22.4587 70.1947 26.1469 70.4654 29.7758C70.6685 32.5419 72.4959 33.7093 75.4655 33.4893C78.0035 33.3032 79.1541 32.0598 79.1964 29.2175C79.1964 27.1704 79.171 25.081 79.171 22.9917H79.1795Z"
                              fill="#89DC65" />
                    </svg>
                    `

        let paper = `
                    <svg width="82" height="110" viewBox="0 0 82 126" fill="none"
                         xmlns="http://www.w3.org/2000/svg">
                        <path d="M19.9708 55.9292V41.8443C19.9708 33.6198 19.8575 25.3953 20.0416 17.1779C20.0571 14.5654 20.5738 11.9801 21.5637 9.56218C23.9069 4.19716 30.7668 2.56218 35.6516 5.89585C36.0268 6.15773 36.3595 6.44084 36.94 6.83013C38.6815 2.39231 41.4779 -0.601619 46.6245 0.0778554C51.4385 0.72194 54.0791 3.75834 55.1198 8.4368C59.1621 5.93124 63.176 5.60566 66.9989 8.4368C70.8217 11.2679 70.5952 15.5925 70.758 19.6057C72.2305 19.4151 73.7123 19.304 75.1968 19.273C76.0929 19.2719 76.9803 19.4494 77.8072 19.795C78.634 20.1406 79.3837 20.6475 80.0124 21.286C80.6412 21.9244 81.1364 22.6818 81.4691 23.5137C81.8019 24.3457 81.9655 25.2356 81.9504 26.1314C81.9929 44.5339 82.092 62.8655 81.8867 81.2326C81.8372 85.7836 79.055 89.5207 76.3011 93.0526C76.1741 93.2487 76.0163 93.4232 75.8339 93.5693C73.1933 95.3812 72.8039 97.9292 72.8818 100.959C73.0517 108.249 72.8818 115.539 72.8818 122.829C72.8818 125.172 72.0606 125.993 69.7386 125.993H32.7561C30.4128 125.993 29.5846 125.193 29.5846 122.857C29.5846 114.633 29.5846 106.408 29.5208 98.1911C29.4746 97.1865 29.0732 96.2309 28.3882 95.4944C20.0133 87.0789 11.596 78.6421 3.02287 70.4317C-1.40172 66.185 -0.339809 61.9383 2.3645 58.4843C5.96788 53.8625 13.2384 51.5339 18.9585 55.3701C19.1709 55.5045 19.4257 55.6249 19.9708 55.9292ZM68.0254 121.088V119.503C68.082 111.717 68.1528 103.882 68.167 96.0677C68.167 94.454 68.8749 93.4631 70.0642 92.4014C74.2694 88.5794 77.4621 84.1628 77.4551 78.1254C77.4551 61.9171 77.4385 45.7064 77.4055 29.4934C77.4055 28.6795 77.4055 27.8584 77.3701 27.0445C77.2144 24.9211 76.1524 23.8594 74.1985 23.9019C71.8978 23.9515 70.6589 25.0981 70.6589 27.2639C70.6589 28.0212 70.6589 28.7786 70.6589 29.5359C70.6589 35.8918 70.6589 42.2477 70.6589 48.6036C70.6589 49.906 70.489 51.088 68.9952 51.5056C67.1121 52.0364 65.8733 50.9464 65.8733 48.731C65.8733 38.001 65.8733 27.271 65.8733 16.5409C65.8733 13.2427 64.1459 11.3812 61.2717 11.2679C58.0506 11.1405 56.0542 12.9454 55.7569 16.2791C55.679 17.1496 55.679 18.0273 55.679 18.8979C55.679 28.637 55.679 38.3761 55.6224 48.1153C55.6227 49.1225 55.2436 50.0929 54.5605 50.8332C54.1792 51.0566 53.7477 51.1802 53.3059 51.1926C52.8641 51.205 52.4263 51.1057 52.0331 50.9039C51.6835 50.5931 51.4022 50.213 51.2072 49.7878C51.0122 49.3626 50.9078 48.9015 50.9005 48.4338C50.8367 37.003 50.9005 25.5794 50.8297 14.1486C50.7689 11.8925 50.385 9.65683 49.6899 7.5096C49.1094 5.61274 47.4245 4.83418 45.3998 4.85541C44.5715 4.8286 43.7586 5.08251 43.0929 5.57591C42.4272 6.0693 41.9478 6.7732 41.7327 7.5733C41.0071 9.46982 40.5543 11.4596 40.3876 13.4833C40.1611 20.9434 40.1682 28.4034 40.1115 35.8635C40.1115 40.181 40.1115 44.4914 40.1115 48.8089C40.1115 50.7128 39.3187 51.64 37.7754 51.64C36.2321 51.64 35.4321 50.727 35.3967 48.8726C35.3967 48.5824 35.3967 48.2922 35.3967 48.002C35.3967 37.5056 35.3967 27.0091 35.3967 16.5126C35.3911 15.059 35.1838 13.6131 34.7808 12.2164C34.1295 10.0081 32.657 9.12335 30.0943 9.09504C27.7439 9.09504 26.3847 9.80282 25.7051 12.0253C25.1799 13.6862 24.9009 15.415 24.8768 17.1567C24.8154 31.2133 24.8154 45.2676 24.8768 59.3195C24.916 60.1099 25.2317 60.8615 25.7688 61.4429C27.8501 63.5662 30.0164 65.6046 32.2322 67.5935C32.4856 67.7902 32.7762 67.9336 33.0864 68.0151C33.3966 68.0966 33.7201 68.1145 34.0375 68.0677C38.3451 67.2067 42.8188 68.064 46.5028 70.4564C50.1868 72.8488 52.7889 76.5867 53.7534 80.8716C54.2241 82.8647 54.2235 84.9402 53.7516 86.933C53.2797 88.9259 52.3496 90.7813 51.035 92.3519C49.7607 93.9656 48.5643 94.2133 47.3183 93.2295C46.0723 92.2457 46.037 91.0354 47.2334 89.4429C48.0198 88.5011 48.6031 87.407 48.9466 86.2292C49.2901 85.0514 49.3866 83.8154 49.2297 82.5986C48.1749 75.457 40.7345 70.8423 33.9596 73.1992C33.3702 73.4686 32.7107 73.5453 32.0752 73.4182C31.4396 73.2911 30.8604 72.9668 30.4199 72.4914C28.3952 70.5592 26.3281 68.6694 24.2963 66.7371C21.9318 64.4934 19.723 62.0586 17.2169 59.999C13.3799 56.8777 8.01379 58.0597 5.52894 62.3418C4.43165 64.2174 4.58034 65.1163 6.1378 66.6451C14.9823 75.3744 23.8243 84.1038 32.6641 92.8332C33.2627 93.3817 33.7349 94.0539 34.0479 94.8031C34.3608 95.5523 34.507 96.3606 34.4764 97.1719C34.4056 104.519 34.4339 111.866 34.4339 119.212V121.095L68.0254 121.088Z"
                              fill="#89DC65" />
                    </svg>
                    `

        let scissors = `
                        <svg width="75" height="110" viewBox="0 0 71 126" fill="none"
                             xmlns="http://www.w3.org/2000/svg">
                            <path d="M0 63.5784C0.936713 60.6651 1.70439 57.6812 2.85944 54.8596C4.07082 51.8969 5.97947 49.4068 9.50798 48.3698C9.09245 45.7528 8.69805 43.1357 8.25434 40.5257C6.94435 32.7662 5.56393 25.0067 4.30324 17.1908C3.0003 9.14208 8.6417 3.56937 16.241 5.31878C17.6179 5.6086 18.8845 6.28325 19.8942 7.26455C20.9038 8.24586 21.6152 9.49363 21.9458 10.8633C22.96 14.475 23.5728 18.2066 24.3545 21.8888L24.5236 22.6718H25.094C25.094 19.2576 25.0236 15.8364 25.1292 12.4293C25.1472 10.4576 25.3834 8.49395 25.8335 6.57441C26.2579 4.8041 27.2408 3.21799 28.6364 2.05147C30.032 0.884945 31.7659 0.200158 33.5808 0.098745C35.0235 -0.0330868 36.4764 -0.00232319 37.9122 0.190451C41.8351 0.74067 44.441 3.23076 44.603 7.24453C44.8636 13.7978 44.7157 20.3651 44.7439 26.9254V29.5848C49.6739 28.2163 53.949 28.8794 56.893 32.738C59.3228 32.5405 61.492 32.1384 63.6401 32.2442C68.2462 32.477 71.0282 35.4115 71.0352 40.0037C71.0352 49.5972 70.9437 59.1837 70.8732 68.7702C70.8732 71.7894 70.6478 74.8226 70.7957 77.8347C71.162 84.9382 68.056 90.391 62.8936 94.8562C62.4039 95.2384 62.0182 95.738 61.772 96.3087C61.5259 96.8795 61.4271 97.5032 61.485 98.1223C61.6188 106.432 61.647 114.742 61.6892 123.051C61.6892 125.055 60.7384 125.979 58.6819 125.979H21.5796C19.4245 125.979 18.5159 125.012 18.5159 122.706C18.5159 114.34 18.5159 105.966 18.4666 97.6003C18.4224 96.5975 18.0624 95.6345 17.4383 94.8492C14.0577 90.7155 10.5503 86.6805 7.13451 82.5751C3.57645 78.4348 1.12211 73.4601 0 68.1142V63.5784ZM35.3838 69.5673C35.7852 69.9059 35.9965 70.0964 36.2289 70.2728C45.1665 77.1505 43.1592 86.6947 38.7433 92.8035C38.5867 93.0835 38.3738 93.328 38.1181 93.5214C37.8624 93.7148 37.5694 93.853 37.2577 93.9273C36.9459 94.0015 36.6222 94.0102 36.3069 93.9528C35.9917 93.8953 35.6917 93.773 35.426 93.5935C34.2006 92.9305 34.0175 91.5479 34.8556 90.1018C35.3486 89.2482 35.905 88.43 36.3275 87.5411C38.9475 82.0813 37.8559 77.5102 33.0314 73.8915C31.9419 73.0285 30.761 72.2881 29.51 71.6836C28.3728 71.1603 27.1467 70.8587 25.8969 70.7947C21.9529 70.703 18.0018 70.7947 14.0577 70.7947C12.1632 70.7947 11.142 69.8072 11.2406 68.2553C11.3392 66.7034 12.297 66.0403 14.1493 65.998C19.4878 65.8992 24.8194 65.8005 30.1579 65.6594C32.722 65.6658 35.2133 64.8059 37.229 63.2187C38.5365 62.1916 39.5697 60.8562 40.2364 59.3319C41.5675 55.8824 39.5321 52.828 36.0951 52.8068C28.0873 52.7504 20.0795 52.7363 12.0787 52.8703C11.4564 52.8812 10.8427 53.0174 10.274 53.2706C9.70535 53.5239 9.19335 53.8892 8.76847 54.3446C6.07806 58.0269 4.47227 62.2029 4.77512 66.8374C5.08501 71.6201 7.5923 75.528 10.494 79.1115C14.2338 83.6967 18.199 88.0984 21.9177 92.7047C22.7404 93.7918 23.2056 95.1082 23.2488 96.4716C23.3685 104.019 23.3051 111.574 23.3051 119.129V121.062H56.7803C56.8296 120.54 56.9071 120.089 56.9071 119.651C56.8577 112.16 56.907 104.661 56.6958 97.17C56.6044 96.1161 56.7928 95.0567 57.2417 94.0991C57.6907 93.1416 58.3843 92.3198 59.2524 91.7172C63.6753 88.2536 66.2601 83.7602 65.9995 77.9053C65.9079 75.9372 66.0981 73.955 66.1051 71.9799C66.1051 67.2325 66.1051 62.478 66.1051 57.6107C62.3019 58.5489 58.7664 58.3937 55.6745 55.8401C52.7024 58.9933 49.1457 58.9439 45.4411 57.9563C44.603 64.0511 40.8491 67.4017 35.3838 69.5673ZM39.6589 48.13C39.6589 47.7843 39.6589 47.213 39.6589 46.6486C39.7152 41.9459 39.7692 37.2432 39.8208 32.5405C39.9054 24.6329 40.004 16.7323 40.0462 8.8317C40.0462 6.01007 39.0039 4.91669 36.243 4.69096C32.1581 4.35942 30.0804 6.26402 29.9678 10.4189C29.686 21.2822 29.402 32.1454 29.1156 43.0087C29.0803 44.6171 29.1156 46.2324 29.1156 48.1441L39.6589 48.13ZM23.6784 47.9536C23.6784 47.4175 23.6784 46.9519 23.6009 46.5428C22.1923 38.1343 20.8401 29.7259 19.4104 21.3245C18.9385 18.5028 18.3962 15.7306 17.7553 12.9724C17.4031 11.4629 16.6918 10.0239 14.8747 9.90393C11.4096 9.67115 8.22617 10.6799 8.97272 15.5966C10.2545 24.0191 11.6843 32.4206 13.0647 40.822C13.452 43.1992 13.9098 45.5623 14.3465 47.9818L23.6784 47.9536ZM53.2588 43.3332C53.2588 42.3456 53.2588 41.3581 53.2588 40.3705C53.2588 39.3829 53.2588 38.3954 53.2588 37.4078C53.2588 34.9671 51.5967 33.5774 48.7161 33.5704C48.196 33.539 47.6749 33.6119 47.1833 33.7848C46.6917 33.9576 46.2395 34.2271 45.8531 34.5772C45.4668 34.9274 45.1541 35.3512 44.9334 35.8239C44.7127 36.2967 44.5884 36.8087 44.5678 37.3302C44.4786 41.3322 44.3988 45.3295 44.3283 49.3221C44.272 52.1438 45.906 53.7309 48.871 53.8226C51.5826 53.9073 53.1884 52.4118 53.2588 49.5902C53.3151 47.5374 53.2729 45.4424 53.2729 43.3544L53.2588 43.3332ZM66.2037 45.5835H66.3657C66.3657 44.0739 66.3657 42.5643 66.3657 41.0618C66.3657 37.5912 64.9571 36.4767 61.1962 36.8787C58.703 37.1397 58.0339 38.0356 58.0269 40.5398C58.0269 43.2627 58.0269 45.9903 58.0269 48.7225C58.0269 52.4965 60.4215 54.2459 64.0909 53.1948C65.4995 52.7857 66.2601 51.9956 66.2037 50.4578C66.1474 48.92 66.2037 47.1989 66.2037 45.5835Z"
                                  fill="#89DC65" />
                        </svg>
                        `

        axios.post("/Home/Game", obj)
            .then(function (response) {

                let compScore = response.data.compScore;
                let userScore = response.data.userScore;
                let result = response.data.result;
                let hasWon = response.data.hasWon;
                let compSelected = response.data.compSelected;
                let message = response.data.message;

                if (obj.selected == 1) {
                    $('.absolutuser').html(rock);
                    $('.absolutuser').addClass('moveright');
                }
                else if (obj.selected == 2) {
                    $('.absolutuser').html(paper);
                    $('.absolutuser').addClass('moveright');
                }
                else if (obj.selected == 3) {
                    $('.absolutuser').html(scissors);
                    $('.absolutuser').addClass('moveright');
                }

                if (compSelected == 1) {
                    $('.absolutcomp').html(rock);
                    $('.absolutcomp').addClass('moveleft');
                }
                else if (compSelected == 2) {
                    $('.absolutcomp').html(paper);
                    $('.absolutcomp').addClass('moveleft');
                }
                else if (compSelected == 3) {
                    $('.absolutcomp').html(scissors);
                    $('.absolutcomp').addClass('moveleft');
                }

                if (result == 0) {
                    $("#result").addClass("text-warning");
                    $("#result").removeClass("text-danger");
                    $("#result").removeClass("text-success");
                }
                else if (result == 1) {
                    $("#result").removeClass("text-danger");
                    $("#result").removeClass("text-warning");
                    $("#result").addClass("text-success");
                }
                else if (result == -1) {
                    $("#result").removeClass("text-warning");
                    $("#result").removeClass("text-success");
                    $("#result").addClass("text-danger");
                }

                $("#result").html(message);

                if (hasWon == 1) {
                    $("#ifwon").html("Təbriklər! Siz 7:0 etdiyiniz üçün 3 manat qazandiniz! 24 saat ərzində sizin nömrəniz ilə əlaqə saxlayacayıq!");
                    $("#ifwon").removeClass("d-none");
                    $("#vopros").removeClass("d-none");
                    $("#reload").addClass("d-none");
                    $(".fifth").addClass("d-none");

                    if (result == 0) {
                        $("#ifwon").html("");
                        $("#ifwon").addClass("d-none");
                        $("#vopros").addClass("d-none");
                        $("#reload").removeClass("d-none");
                        $(".fifth").removeClass("d-none");
                    }
                }

                if (hasWon == 2) {
                    $("#ifwon").html("Təbriklər! Siz 10:0 etdiyiniz üçün 30 manat qazandiniz! 24 saat ərzində sizin nömrəniz ilə əlaqə saxlayacayıq!");
                    $("#ifwon").removeClass("d-none");

                    axios.get("/Home/CreateEvent")
                        .then(function (response) {
                            toastr.success('Oyna!');
                            $("#result").removeClass("text-warning");
                            $("#result").removeClass("text-danger");
                            $("#result").removeClass("text-success");
                            $("#result").html("Oyunu Başlayın");
                            $('#user').html("0");
                            $('#comp').html("0");
                        })
                }

                $('.preloaderdiv').addClass('d-none');

                //setTimeout(() => {
                //    $('.absolutuser').removeClass('moveright');
                //    $('.absolutcomp').removeClass('moveleft');
                //}, 700);

                $('#user').html(userScore);
                $('#comp').html(compScore);
            })
            .catch(function (err) {
                toastr.warning('Error!');
                $('#user').html("0");
                $('#comp').html("0");
                return;
            });
    })

    //#region reload

    $(document).on('click', '#reload', function () {
        $('.preloaderdiv').removeClass('d-none')
        $('.absolutuser').removeClass('moveright');
        $('.absolutcomp').removeClass('moveleft');
        axios.get("/Home/CreateEvent")
            .then(function (response) {
                toastr.success('Oyna!');
                $("#result").removeClass("text-warning");
                $("#result").removeClass("text-danger");
                $("#result").removeClass("text-success");
                $("#result").html("Oyunu Başlayın");
                $('#user').html("0");
                $('#comp').html("0");
                $('.preloaderdiv').addClass('d-none')
            })
    })

    //#endregion reload

    //#region vopros

    $(document).on('click', '#yes', function () {
        $("#ifwon").html("");
        $("#ifwon").addClass("d-none");
        $("#vopros").addClass("d-none");
        $("#reload").removeClass("d-none");
        $(".fifth").removeClass("d-none");
    })

    $(document).on('click', '#no', function () {
        axios.get("/Home/CreateEvent")
            .then(function (response) {
                toastr.success('Oyna!');
                $("#result").removeClass("text-warning");
                $("#result").removeClass("text-danger");
                $("#result").removeClass("text-success");
                $("#result").html("Oyunu Başlayın");
                $('#user').html("0");
                $('#comp').html("0");
                $("#ifwon").html("");
                $("#ifwon").addClass("d-none");
                $("#vopros").addClass("d-none");
                $("#reload").removeClass("d-none");
                $(".fifth").removeClass("d-none");
            })
    })

    //#endregion vopros

    //#endregion game

    //#region prevent letters and nonnumeric

    $(document).on('input', '#phoneno', function (e) {
        if (!/^[0-9]+$/.test($(this).val())) {
            $(this).val($(this).val().slice(0, -1))
        }
    })

    //#endregion prevent letters and nonnumeric

    //#region submit login

    $(document).on('submit', '#loginform', function (e) {
        const formData = new FormData(e.target);
        let phoneno = formData.get('Login');

        if (!(phoneno.startsWith("50") ||
            phoneno.startsWith("10") ||
            phoneno.startsWith("51") ||
            phoneno.startsWith("70") ||
            phoneno.startsWith("77") ||
            phoneno.startsWith("99") ||
            phoneno.startsWith("55"))) {
            e.preventDefault();
            toastr.error('Nömrə səhvdir.');
            return;
        }

        if (phoneno.length != 9) {
            e.preventDefault();
            toastr.error('Məlumatlar səhvdir.');
            return;
        }
    })

    //#endregion submit login

    //#region login input focus on click on span

    $(document).on('click', '.kodstrani', function () {
        $('#phoneno').focus();
    })

    //#endregion login input focus on click on span



});