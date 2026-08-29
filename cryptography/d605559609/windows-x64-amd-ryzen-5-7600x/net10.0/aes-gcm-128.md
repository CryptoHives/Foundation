| Description                                           | TestDataSize | Mean          | Error         | StdDev        | Median        | Allocated |
|------------------------------------------------------ |------------- |--------------:|--------------:|--------------:|--------------:|----------:|
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |     118.19 ns |      1.589 ns |      1.486 ns |     117.70 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 17B          |     123.63 ns |      2.007 ns |      1.676 ns |     123.78 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |     124.18 ns |      2.237 ns |      2.093 ns |     124.55 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 17B          |     351.86 ns |      7.020 ns |      6.566 ns |     350.24 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 17B          |     527.35 ns |     10.399 ns |     14.577 ns |     525.07 ns |    1624 B |
|                                                       |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 17B          |      73.09 ns |      1.481 ns |      2.348 ns |      72.19 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 17B          |      74.93 ns |      1.485 ns |      1.768 ns |      74.79 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 17B          |     127.68 ns |      2.431 ns |      2.155 ns |     127.09 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 17B          |     318.33 ns |      6.198 ns |      8.059 ns |     315.83 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 17B          |     462.64 ns |      6.742 ns |      6.622 ns |     462.90 ns |    1608 B |
|                                                       |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |     107.17 ns |      2.109 ns |      3.857 ns |     105.30 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |     110.63 ns |      1.822 ns |      1.615 ns |     110.57 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 65B          |     135.68 ns |      2.688 ns |      2.876 ns |     135.10 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 65B          |     612.88 ns |     12.232 ns |     24.144 ns |     607.16 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 65B          |     721.94 ns |     14.342 ns |     24.740 ns |     717.90 ns |    1624 B |
|                                                       |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 65B          |      74.69 ns |      0.827 ns |      0.773 ns |      74.90 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 65B          |      75.98 ns |      1.295 ns |      1.684 ns |      75.67 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 65B          |     131.35 ns |      2.299 ns |      1.919 ns |     131.18 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 65B          |     577.17 ns |     10.252 ns |      9.088 ns |     575.12 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 65B          |     607.96 ns |      7.735 ns |      6.459 ns |     606.65 ns |    1608 B |
|                                                       |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |     101.56 ns |      1.329 ns |      1.178 ns |     101.53 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |     102.66 ns |      1.702 ns |      2.386 ns |     102.42 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 128B         |     125.03 ns |      1.901 ns |      1.685 ns |     124.72 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 128B         |     833.79 ns |     15.338 ns |     14.347 ns |     833.25 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 128B         |     869.52 ns |     15.665 ns |     23.922 ns |     863.08 ns |    1624 B |
|                                                       |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128B         |      64.84 ns |      1.280 ns |      1.370 ns |      64.58 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128B         |      64.92 ns |      0.923 ns |      0.864 ns |      64.79 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 128B         |     124.31 ns |      2.488 ns |      2.765 ns |     123.78 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 128B         |     774.99 ns |     11.840 ns |      9.887 ns |     775.66 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 128B         |     826.81 ns |      7.063 ns |      6.606 ns |     824.96 ns |         - |
|                                                       |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |     133.66 ns |      2.556 ns |      2.625 ns |     133.68 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |     136.57 ns |      2.688 ns |      2.514 ns |     135.66 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 152B         |     139.34 ns |      2.793 ns |      2.332 ns |     139.07 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 152B         |   1,012.15 ns |     19.345 ns |     18.999 ns |   1,012.85 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 152B         |   1,035.50 ns |     14.675 ns |     13.727 ns |   1,032.90 ns |         - |
|                                                       |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 152B         |      93.93 ns |      1.708 ns |      2.450 ns |      93.25 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 152B         |      97.87 ns |      1.974 ns |      3.707 ns |      96.66 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 152B         |     151.60 ns |      2.223 ns |      2.812 ns |     151.54 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 152B         |     906.19 ns |     17.195 ns |     16.085 ns |     906.61 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 152B         |     989.80 ns |     19.502 ns |     34.157 ns |     981.26 ns |         - |
|                                                       |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |     113.59 ns |      1.236 ns |      1.095 ns |     113.97 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |     127.33 ns |      2.404 ns |      2.361 ns |     126.24 ns |         - |
| Decrypt · AES-128-GCM (OS)                            | 256B         |     129.51 ns |      1.091 ns |      0.911 ns |     129.64 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 256B         |   1,260.11 ns |     17.690 ns |     16.547 ns |   1,253.63 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 256B         |   1,491.13 ns |     18.626 ns |     21.449 ns |   1,490.59 ns |         - |
|                                                       |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 256B         |      79.04 ns |      0.962 ns |      0.900 ns |      79.02 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 256B         |      84.50 ns |      1.500 ns |      1.330 ns |      84.59 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 256B         |     128.50 ns |      1.819 ns |      1.420 ns |     128.93 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 256B         |   1,183.66 ns |     22.459 ns |     19.909 ns |   1,180.12 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 256B         |   1,448.93 ns |     19.417 ns |     17.212 ns |   1,450.41 ns |         - |
|                                                       |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (OS)                            | 1KB          |     183.79 ns |      1.945 ns |      1.820 ns |     183.58 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     206.48 ns |      2.517 ns |      2.102 ns |     205.57 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     251.87 ns |      4.763 ns |      5.294 ns |     252.61 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 1KB          |   3,773.88 ns |     40.022 ns |     37.437 ns |   3,779.67 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 1KB          |   5,321.59 ns |     67.275 ns |     59.638 ns |   5,308.44 ns |         - |
|                                                       |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 1KB          |     188.49 ns |      3.541 ns |      8.137 ns |     185.98 ns |         - |
| Encrypt · AES-128-GCM (OS)                            | 1KB          |     196.42 ns |      3.921 ns |      4.358 ns |     196.19 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 1KB          |     218.67 ns |      5.269 ns |     15.454 ns |     212.03 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 1KB          |   4,382.46 ns |    173.531 ns |    511.659 ns |   4,341.76 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 1KB          |   5,740.70 ns |    114.782 ns |    149.249 ns |   5,703.87 ns |         - |
|                                                       |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (OS)                            | 8KB          |     730.62 ns |     12.428 ns |     11.625 ns |     732.07 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,076.83 ns |     14.839 ns |     13.155 ns |   1,075.65 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,426.64 ns |     27.757 ns |     28.504 ns |   1,418.02 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 8KB          |  26,553.74 ns |    411.217 ns |    321.051 ns |  26,513.14 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 8KB          |  43,114.09 ns |    484.385 ns |    378.176 ns |  43,028.31 ns |         - |
|                                                       |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (OS)                            | 8KB          |     704.41 ns |     13.941 ns |     14.316 ns |     706.39 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 8KB          |   1,240.91 ns |     36.178 ns |    102.631 ns |   1,234.87 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 8KB          |   1,348.26 ns |     21.671 ns |     19.211 ns |   1,341.90 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 8KB          |  26,936.59 ns |    516.216 ns |    482.869 ns |  26,806.02 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 8KB          |  43,814.21 ns |    855.806 ns |    758.650 ns |  43,606.58 ns |         - |
|                                                       |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (OS)                            | 128KB        |  11,256.66 ns |    199.153 ns |    166.302 ns |  11,223.39 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  16,638.59 ns |    212.272 ns |    208.480 ns |  16,605.57 ns |         - |
| Decrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  21,574.89 ns |    322.421 ns |    285.818 ns |  21,478.05 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)                  | 128KB        | 421,349.75 ns |  7,055.250 ns |  5,891.453 ns | 420,499.90 ns |    1624 B |
| Decrypt · AES-128-GCM (CryptoHives-Scalar)            | 128KB        | 668,423.90 ns |  8,811.536 ns |  7,811.197 ns | 667,535.01 ns |         - |
|                                                       |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (OS)                            | 128KB        |  10,310.19 ns |    171.774 ns |    183.797 ns |  10,282.73 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMulV256) | 128KB        |  17,819.77 ns |    335.235 ns |    358.698 ns |  17,783.81 ns |         - |
| Encrypt · AES-128-GCM (CryptoHives-AES-NI+PClMul)     | 128KB        |  21,259.14 ns |    415.397 ns |    368.238 ns |  21,248.81 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)                  | 128KB        | 424,198.90 ns |  7,772.507 ns |  7,270.408 ns | 424,669.09 ns |    1608 B |
| Encrypt · AES-128-GCM (CryptoHives-Scalar)            | 128KB        | 676,815.58 ns | 12,238.319 ns | 10,219.551 ns | 676,486.72 ns |         - |