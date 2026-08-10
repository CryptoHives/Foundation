| Description                                  | TestDataSize | Mean             | Error         | StdDev        | Median           | Allocated |
|--------------------------------------------- |------------- |-----------------:|--------------:|--------------:|-----------------:|----------:|
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 4B           |         52.97 ns |      0.036 ns |      0.032 ns |         52.97 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 4B           |         54.31 ns |      0.115 ns |      0.107 ns |         54.36 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 4B           |         64.76 ns |      0.082 ns |      0.077 ns |         64.76 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 4B           |         64.79 ns |      0.199 ns |      0.176 ns |         64.74 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 4B           |         64.85 ns |      1.331 ns |      2.657 ns |         63.29 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 4B           |        331.62 ns |      0.662 ns |      0.620 ns |        331.65 ns |         - |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 100B         |        100.52 ns |      0.091 ns |      0.085 ns |        100.55 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 100B         |        109.22 ns |      0.065 ns |      0.057 ns |        109.24 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 100B         |        122.98 ns |      0.322 ns |      0.302 ns |        123.00 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 100B         |        124.64 ns |      0.060 ns |      0.056 ns |        124.64 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 100B         |        124.73 ns |      0.120 ns |      0.112 ns |        124.77 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 100B         |        723.54 ns |      1.623 ns |      1.439 ns |        723.79 ns |         - |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 128B         |        100.55 ns |      0.108 ns |      0.096 ns |        100.58 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 128B         |        109.27 ns |      0.123 ns |      0.115 ns |        109.29 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 128B         |        123.11 ns |      0.066 ns |      0.059 ns |        123.12 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 128B         |        124.22 ns |      0.058 ns |      0.054 ns |        124.22 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128B         |        124.29 ns |      0.100 ns |      0.089 ns |        124.32 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128B         |        724.12 ns |      0.461 ns |      0.431 ns |        724.16 ns |         - |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 137B         |        147.66 ns |      0.302 ns |      0.252 ns |        147.75 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 137B         |        165.73 ns |      0.182 ns |      0.142 ns |        165.70 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 137B         |        180.52 ns |      0.128 ns |      0.120 ns |        180.54 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 137B         |        180.83 ns |      0.155 ns |      0.138 ns |        180.78 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 137B         |        183.36 ns |      0.154 ns |      0.144 ns |        183.34 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 137B         |      1,078.03 ns |      0.838 ns |      0.784 ns |      1,078.10 ns |         - |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1000B        |        779.20 ns |      0.771 ns |      0.721 ns |        779.50 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1000B        |        899.01 ns |      1.051 ns |      0.932 ns |        899.38 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1000B        |        904.19 ns |      0.519 ns |      0.485 ns |        904.27 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1000B        |        911.99 ns |      0.797 ns |      0.745 ns |        912.10 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1000B        |        971.66 ns |      0.465 ns |      0.434 ns |        971.72 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1000B        |      5,500.59 ns |      3.606 ns |      3.011 ns |      5,501.02 ns |         - |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1KB          |        778.25 ns |      1.396 ns |      1.166 ns |        778.46 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1KB          |        898.70 ns |      2.013 ns |      1.784 ns |        899.41 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1KB          |        904.60 ns |      0.879 ns |      0.687 ns |        904.70 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1KB          |        909.91 ns |      0.188 ns |      0.147 ns |        909.95 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1KB          |        970.31 ns |      2.615 ns |      2.446 ns |        971.53 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1KB          |      5,477.95 ns |     12.591 ns |     11.161 ns |      5,481.40 ns |         - |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1025B        |        878.26 ns |      1.934 ns |      1.714 ns |        879.02 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1025B        |      1,025.66 ns |      0.728 ns |      0.645 ns |      1,025.93 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1025B        |      1,038.42 ns |      1.149 ns |      1.075 ns |      1,038.59 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1025B        |      1,039.98 ns |      0.531 ns |      0.471 ns |      1,040.03 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1025B        |      1,143.05 ns |      4.721 ns |      4.416 ns |      1,141.49 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1025B        |      6,209.15 ns |      4.378 ns |      4.095 ns |      6,210.05 ns |      56 B |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 2KB          |      1,600.49 ns |      3.272 ns |      3.060 ns |      1,601.74 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 2KB          |      1,872.00 ns |      3.839 ns |      3.205 ns |      1,872.98 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 2KB          |      1,873.83 ns |      0.608 ns |      0.508 ns |      1,873.66 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 2KB          |      1,875.24 ns |      1.110 ns |      1.039 ns |      1,875.18 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 2KB          |      2,064.18 ns |      3.414 ns |      2.851 ns |      2,064.07 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 2KB          |     11,269.75 ns |      7.885 ns |      6.156 ns |     11,270.62 ns |      56 B |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 4KB          |      1,758.00 ns |      3.636 ns |      3.223 ns |      1,757.67 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 4KB          |      2,021.42 ns |      3.835 ns |      3.587 ns |      2,022.59 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 4KB          |      2,141.96 ns |     10.248 ns |      8.001 ns |      2,141.42 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 4KB          |      3,132.28 ns |      7.243 ns |      6.421 ns |      3,133.12 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 4KB          |      3,804.89 ns |      6.050 ns |      5.052 ns |      3,806.50 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 4KB          |     22,871.76 ns |     14.648 ns |     12.232 ns |     22,872.49 ns |     168 B |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 6KB          |      3,357.55 ns |      9.936 ns |      9.294 ns |      3,358.53 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 6KB          |      3,937.75 ns |     11.627 ns |     10.876 ns |      3,939.38 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 6KB          |      4,074.60 ns |     12.781 ns |     11.330 ns |      4,074.13 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 6KB          |      4,245.83 ns |      9.360 ns |      8.297 ns |      4,244.74 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 6KB          |      5,735.43 ns |      4.085 ns |      3.621 ns |      5,737.00 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 6KB          |     34,479.00 ns |     30.925 ns |     28.927 ns |     34,488.15 ns |     280 B |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 8KB          |      3,459.60 ns |      6.863 ns |      6.420 ns |      3,460.10 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 8KB          |      3,956.21 ns |     15.993 ns |     14.960 ns |      3,959.47 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 8KB          |      4,341.32 ns |     10.857 ns |      9.066 ns |      4,338.69 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 8KB          |      5,288.37 ns |     29.699 ns |     27.781 ns |      5,284.02 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 8KB          |      7,666.86 ns |      3.550 ns |      3.321 ns |      7,666.93 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 8KB          |     45,994.19 ns |    156.232 ns |    138.496 ns |     46,059.16 ns |     392 B |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 10000B       |      4,841.69 ns |     21.988 ns |     19.491 ns |      4,840.15 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 10000B       |      5,691.48 ns |     19.558 ns |     18.295 ns |      5,684.84 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 10000B       |      6,059.42 ns |     12.354 ns |     10.951 ns |      6,056.62 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 10000B       |      6,196.31 ns |     18.290 ns |     15.273 ns |      6,198.78 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 10000B       |      9,435.67 ns |      3.756 ns |      3.514 ns |      9,437.38 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 10000B       |     56,703.98 ns |    116.419 ns |    108.898 ns |     56,738.20 ns |     504 B |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 64KB         |     27,195.21 ns |    104.277 ns |     97.541 ns |     27,166.85 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 64KB         |     31,134.41 ns |     94.613 ns |     88.501 ns |     31,134.28 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 64KB         |     34,790.79 ns |    149.622 ns |    132.636 ns |     34,769.86 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 64KB         |     35,352.18 ns |    117.031 ns |     97.726 ns |     35,325.21 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 64KB         |     61,692.03 ns |     32.798 ns |     30.679 ns |     61,698.95 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 64KB         |    369,768.37 ns |    269.022 ns |    251.643 ns |    369,823.22 ns |    3528 B |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 100000B      |     42,013.61 ns |    175.718 ns |    164.367 ns |     42,039.49 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 100000B      |     48,269.63 ns |    184.549 ns |    163.598 ns |     48,271.70 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 100000B      |     51,606.07 ns |    167.733 ns |    156.898 ns |     51,599.24 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 100000B      |     53,376.02 ns |    100.560 ns |     94.064 ns |     53,389.83 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 100000B      |     94,232.20 ns |    156.388 ns |    130.591 ns |     94,264.40 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 100000B      |    564,156.53 ns |    481.789 ns |    450.665 ns |    564,267.29 ns |    5432 B |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 128KB        |     54,350.96 ns |    165.857 ns |    155.143 ns |     54,345.14 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 128KB        |     62,301.07 ns |    168.132 ns |    149.045 ns |     62,227.18 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 128KB        |     67,482.23 ns |    292.625 ns |    273.722 ns |     67,379.24 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 128KB        |     69,800.96 ns |    166.161 ns |    155.428 ns |     69,824.64 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128KB        |    123,583.83 ns |    110.485 ns |     97.942 ns |    123,603.55 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128KB        |    738,558.23 ns |  1,513.290 ns |  1,415.532 ns |    738,626.67 ns |    7112 B |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 256KB        |    108,651.89 ns |    252.500 ns |    210.849 ns |    108,684.46 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 256KB        |    124,566.91 ns |    187.588 ns |    156.644 ns |    124,526.38 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 256KB        |    132,775.79 ns |    640.282 ns |    598.920 ns |    132,685.66 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 256KB        |    138,800.05 ns |    502.230 ns |    419.385 ns |    138,695.72 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 256KB        |    247,826.74 ns |    198.565 ns |    176.023 ns |    247,812.40 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 256KB        |  1,480,715.13 ns |  1,089.971 ns |  1,019.559 ns |  1,480,537.68 ns |   14280 B |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 512KB        |    217,583.75 ns |    761.879 ns |    712.662 ns |    217,803.47 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 512KB        |    249,297.55 ns |    692.283 ns |    647.562 ns |    249,115.07 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 512KB        |    263,275.38 ns |    684.678 ns |    606.949 ns |    263,198.58 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 512KB        |    276,571.93 ns |    875.877 ns |    776.442 ns |    276,491.47 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 512KB        |    495,478.30 ns |    951.264 ns |    889.813 ns |    495,713.09 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 512KB        |  2,961,078.59 ns |  2,094.360 ns |  1,959.066 ns |  2,961,681.80 ns |   28616 B |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1MB          |    415,411.63 ns |    918.852 ns |    859.494 ns |    415,479.21 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1MB          |    476,033.50 ns |    867.645 ns |    769.145 ns |    476,134.03 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1MB          |    497,723.01 ns |  1,910.724 ns |  1,595.541 ns |    497,645.87 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1MB          |    526,545.96 ns |  1,565.351 ns |  1,464.231 ns |    526,276.90 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1MB          |    944,692.51 ns |  2,001.006 ns |  1,871.742 ns |    945,325.97 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1MB          |  5,652,098.16 ns | 19,052.019 ns | 17,821.270 ns |  5,659,373.70 ns |   54656 B |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 10MB         |  4,157,705.79 ns | 15,193.686 ns | 14,212.183 ns |  4,156,923.18 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 10MB         |  4,755,618.96 ns | 11,229.891 ns | 10,504.447 ns |  4,751,035.16 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 10MB         |  4,989,673.61 ns | 20,243.750 ns | 18,936.016 ns |  4,982,011.06 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 10MB         |  5,271,584.13 ns | 12,496.189 ns | 11,077.546 ns |  5,271,597.66 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 10MB         |  9,459,721.23 ns |  4,390.697 ns |  3,892.239 ns |  9,459,468.12 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 10MB         | 56,639,758.01 ns | 65,315.762 ns | 61,096.404 ns | 56,640,675.89 ns |  546840 B |