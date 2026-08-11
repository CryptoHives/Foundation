| Description                                  | TestDataSize | Mean             | Error          | StdDev        | Median           | Allocated |
|--------------------------------------------- |------------- |-----------------:|---------------:|--------------:|-----------------:|----------:|
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 4B           |         53.52 ns |       0.785 ns |      0.735 ns |         52.99 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 4B           |         54.95 ns |       0.685 ns |      0.641 ns |         54.54 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 4B           |         57.12 ns |       0.775 ns |      0.725 ns |         56.65 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 4B           |         65.44 ns |       0.150 ns |      0.117 ns |         65.47 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 4B           |         65.75 ns |       0.258 ns |      0.201 ns |         65.79 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 4B           |        331.68 ns |       5.552 ns |      5.194 ns |        328.88 ns |         - |
|                                              |              |                  |                |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 100B         |        101.37 ns |       1.477 ns |      1.381 ns |        100.49 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 100B         |        109.99 ns |       1.429 ns |      1.336 ns |        109.17 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 100B         |        117.52 ns |       1.884 ns |      1.763 ns |        116.08 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 100B         |        125.30 ns |       0.217 ns |      0.169 ns |        125.27 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 100B         |        125.46 ns |       0.130 ns |      0.102 ns |        125.43 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 100B         |        725.43 ns |      11.374 ns |     10.640 ns |        720.35 ns |         - |
|                                              |              |                  |                |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 128B         |        101.27 ns |       1.499 ns |      1.402 ns |        100.38 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 128B         |        109.92 ns |       1.379 ns |      1.290 ns |        109.11 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 128B         |        117.74 ns |       1.463 ns |      1.368 ns |        116.69 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 128B         |        125.18 ns |       0.053 ns |      0.042 ns |        125.19 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128B         |        125.32 ns |       0.267 ns |      0.208 ns |        125.41 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128B         |        724.55 ns |      11.286 ns |     10.557 ns |        718.84 ns |         - |
|                                              |              |                  |                |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 137B         |        149.46 ns |       2.905 ns |      2.983 ns |        147.68 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 137B         |        166.68 ns |       2.516 ns |      2.354 ns |        165.46 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 137B         |        177.95 ns |       2.576 ns |      2.409 ns |        176.58 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 137B         |        182.45 ns |       2.844 ns |      2.660 ns |        180.87 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 137B         |        182.54 ns |       2.884 ns |      2.698 ns |        181.11 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 137B         |      1,073.45 ns |       3.439 ns |      2.685 ns |      1,073.62 ns |         - |
|                                              |              |                  |                |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1000B        |        783.33 ns |      10.052 ns |      9.402 ns |        778.05 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1000B        |        906.63 ns |      12.076 ns |     11.296 ns |        899.23 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1000B        |        907.35 ns |      10.853 ns |     10.152 ns |        901.59 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1000B        |        908.81 ns |      12.359 ns |     11.561 ns |        901.12 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1000B        |        960.66 ns |       0.797 ns |      0.622 ns |        960.75 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1000B        |      5,521.42 ns |      76.820 ns |     64.148 ns |      5,496.46 ns |         - |
|                                              |              |                  |                |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1KB          |        782.24 ns |      10.137 ns |      9.482 ns |        776.86 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1KB          |        908.20 ns |      10.687 ns |      9.997 ns |        902.66 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1KB          |        909.64 ns |      15.555 ns |     14.550 ns |        900.50 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1KB          |        909.65 ns |      13.236 ns |     11.733 ns |        901.52 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1KB          |        961.63 ns |       0.453 ns |      0.354 ns |        961.70 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1KB          |      5,504.47 ns |      92.025 ns |     86.080 ns |      5,455.13 ns |         - |
|                                              |              |                  |                |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1025B        |        884.34 ns |      11.122 ns |     10.403 ns |        877.54 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1025B        |      1,016.53 ns |       1.998 ns |      1.560 ns |      1,017.13 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1025B        |      1,039.77 ns |       2.274 ns |      1.776 ns |      1,040.00 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1025B        |      1,056.43 ns |      21.068 ns |     24.262 ns |      1,039.47 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1025B        |      1,083.87 ns |       4.202 ns |      3.281 ns |      1,083.03 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1025B        |      6,287.05 ns |      89.885 ns |     84.079 ns |      6,233.14 ns |      56 B |
|                                              |              |                  |                |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 2KB          |      1,612.88 ns |      24.007 ns |     22.456 ns |      1,598.56 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 2KB          |      1,885.24 ns |      21.133 ns |     19.768 ns |      1,870.91 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 2KB          |      1,889.71 ns |      24.596 ns |     23.007 ns |      1,873.63 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 2KB          |      1,890.90 ns |      25.269 ns |     23.637 ns |      1,873.14 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 2KB          |      1,981.84 ns |       4.194 ns |      3.274 ns |      1,982.34 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 2KB          |     11,363.84 ns |     182.087 ns |    170.324 ns |     11,264.56 ns |      56 B |
|                                              |              |                  |                |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 4KB          |      1,743.50 ns |      17.205 ns |     16.094 ns |      1,737.13 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 4KB          |      2,011.12 ns |       7.631 ns |      5.958 ns |      2,008.56 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 4KB          |      2,061.79 ns |       7.952 ns |      6.208 ns |      2,061.32 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 4KB          |      2,110.79 ns |      11.021 ns |      8.604 ns |      2,108.21 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 4KB          |      3,834.71 ns |      46.192 ns |     43.208 ns |      3,801.66 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 4KB          |     23,004.29 ns |     354.409 ns |    331.514 ns |     22,825.76 ns |     168 B |
|                                              |              |                  |                |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 6KB          |      3,341.09 ns |      42.975 ns |     40.199 ns |      3,321.72 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 6KB          |      3,920.84 ns |      18.441 ns |     14.398 ns |      3,912.92 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 6KB          |      4,061.96 ns |      21.092 ns |     16.467 ns |      4,051.10 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 6KB          |      4,078.92 ns |      17.852 ns |     13.938 ns |      4,076.28 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 6KB          |      5,775.52 ns |      91.049 ns |     85.167 ns |      5,730.39 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 6KB          |     34,381.63 ns |     101.696 ns |     79.397 ns |     34,377.78 ns |     280 B |
|                                              |              |                  |                |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 8KB          |      3,443.64 ns |      32.257 ns |     30.173 ns |      3,429.42 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 8KB          |      3,949.93 ns |      16.498 ns |     12.880 ns |      3,944.82 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 8KB          |      4,139.03 ns |       9.978 ns |      7.790 ns |      4,137.71 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 8KB          |      4,295.66 ns |      18.105 ns |     14.135 ns |      4,292.30 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 8KB          |      7,647.42 ns |      10.402 ns |      8.122 ns |      7,650.63 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 8KB          |     46,287.34 ns |     580.648 ns |    543.139 ns |     45,939.95 ns |     392 B |
|                                              |              |                  |                |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 10000B       |      4,823.93 ns |      18.194 ns |     14.205 ns |      4,823.67 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 10000B       |      5,686.95 ns |      58.103 ns |     51.507 ns |      5,670.46 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 10000B       |      6,025.84 ns |      69.260 ns |     64.786 ns |      6,001.21 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 10000B       |      6,087.60 ns |      81.372 ns |     76.115 ns |      6,054.67 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 10000B       |      9,407.27 ns |      22.434 ns |     17.515 ns |      9,414.54 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 10000B       |     56,890.84 ns |     768.217 ns |    718.591 ns |     56,463.11 ns |     504 B |
|                                              |              |                  |                |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 64KB         |     27,256.01 ns |     285.997 ns |    267.522 ns |     27,112.25 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 64KB         |     31,150.98 ns |     102.291 ns |     79.862 ns |     31,140.99 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 64KB         |     33,427.14 ns |      85.551 ns |     66.792 ns |     33,412.82 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 64KB         |     35,049.38 ns |     636.457 ns |    595.342 ns |     34,731.21 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 64KB         |     61,512.29 ns |      99.443 ns |     77.638 ns |     61,552.40 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 64KB         |    373,113.37 ns |   6,151.530 ns |  5,754.145 ns |    369,506.14 ns |    3528 B |
|                                              |              |                  |                |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 100000B      |     22,575.79 ns |     324.105 ns |    303.168 ns |     22,413.59 ns |    3337 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 100000B      |     42,284.03 ns |     532.686 ns |    498.275 ns |     42,047.17 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 100000B      |     48,527.92 ns |     519.956 ns |    486.367 ns |     48,266.72 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 100000B      |     51,911.84 ns |     631.049 ns |    590.284 ns |     51,596.36 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 100000B      |     95,044.99 ns |   1,515.458 ns |  1,417.560 ns |     94,097.86 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 100000B      |    563,906.70 ns |   1,137.387 ns |    887.997 ns |    563,665.38 ns |    5432 B |
|                                              |              |                  |                |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 128KB        |     24,540.84 ns |     351.513 ns |    328.806 ns |     24,451.54 ns |    3515 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 128KB        |     54,998.31 ns |     458.401 ns |    428.788 ns |     54,730.35 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 128KB        |     62,529.98 ns |     216.238 ns |    168.824 ns |     62,554.47 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 128KB        |     68,495.08 ns |     233.180 ns |    182.052 ns |     68,486.91 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128KB        |    123,358.52 ns |     252.745 ns |    197.327 ns |    123,410.13 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128KB        |    746,162.51 ns |  12,167.209 ns | 11,381.215 ns |    738,577.52 ns |    7112 B |
|                                              |              |                  |                |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 256KB        |     38,507.17 ns |     283.391 ns |    221.253 ns |     38,517.11 ns |    3971 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 256KB        |    110,447.00 ns |     785.665 ns |    696.471 ns |    110,217.43 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 256KB        |    125,523.92 ns |     427.678 ns |    333.903 ns |    125,510.12 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 256KB        |    135,951.14 ns |     344.986 ns |    269.343 ns |    136,010.86 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 256KB        |    247,493.72 ns |     133.566 ns |    104.280 ns |    247,522.97 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 256KB        |  1,491,295.72 ns |  25,720.112 ns | 24,058.609 ns |  1,477,372.15 ns |   14280 B |
|                                              |              |                  |                |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 512KB        |     60,913.40 ns |   1,207.753 ns |  1,292.282 ns |     60,898.24 ns |    3760 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 512KB        |    221,282.14 ns |   1,947.492 ns |  1,821.685 ns |    220,622.33 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 512KB        |    250,982.50 ns |     796.573 ns |    621.911 ns |    250,867.18 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 512KB        |    269,712.02 ns |     433.492 ns |    338.442 ns |    269,672.88 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 512KB        |    495,426.83 ns |     401.382 ns |    313.373 ns |    495,424.15 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 512KB        |  2,967,844.34 ns |  34,698.805 ns | 28,975.073 ns |  2,956,274.57 ns |   28616 B |
|                                              |              |                  |                |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1MB          |    112,831.20 ns |   2,232.592 ns |  2,088.368 ns |    113,582.81 ns |    3742 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1MB          |    424,966.87 ns |   3,885.463 ns |  3,634.464 ns |    423,870.73 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1MB          |    483,567.92 ns |   4,228.429 ns |  3,955.275 ns |    480,673.97 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1MB          |    511,561.65 ns |     787.062 ns |    614.486 ns |    511,679.18 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1MB          |    952,860.36 ns |  11,554.579 ns | 10,808.161 ns |    945,009.16 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1MB          |  5,699,933.03 ns |  84,868.592 ns | 75,233.796 ns |  5,661,183.75 ns |   54656 B |
|                                              |              |                  |                |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 10MB         |    970,503.33 ns |   2,603.072 ns |  2,032.307 ns |    969,843.30 ns |    3821 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 10MB         |  4,240,620.49 ns |  15,394.391 ns | 12,018.928 ns |  4,236,235.67 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 10MB         |  4,851,503.43 ns |  60,295.932 ns | 56,400.852 ns |  4,821,416.02 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 10MB         |  5,158,596.63 ns |  80,968.887 ns | 75,738.347 ns |  5,115,905.27 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 10MB         |  9,449,038.03 ns |  11,065.311 ns |  8,639.067 ns |  9,448,311.52 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 10MB         | 56,621,219.14 ns | 103,006.994 ns | 80,421.085 ns | 56,601,743.00 ns |  546840 B |