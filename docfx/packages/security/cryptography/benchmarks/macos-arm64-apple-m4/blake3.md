| Description                                  | TestDataSize | Mean             | Error         | StdDev        | Median           | Allocated |
|--------------------------------------------- |------------- |-----------------:|--------------:|--------------:|-----------------:|----------:|
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 4B           |         53.06 ns |      0.172 ns |      0.144 ns |         53.02 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 4B           |         55.46 ns |      1.102 ns |      1.269 ns |         54.72 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 4B           |         64.99 ns |      0.102 ns |      0.091 ns |         64.99 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 4B           |         69.36 ns |      0.214 ns |      0.200 ns |         69.36 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 4B           |         85.28 ns |      7.762 ns |     22.396 ns |         79.09 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 4B           |        333.76 ns |      0.296 ns |      0.247 ns |        333.68 ns |         - |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 100B         |        101.90 ns |      0.258 ns |      0.242 ns |        101.94 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 100B         |        110.53 ns |      0.235 ns |      0.209 ns |        110.60 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 100B         |        124.78 ns |      0.466 ns |      0.436 ns |        124.86 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 100B         |        127.90 ns |      0.221 ns |      0.185 ns |        127.98 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 100B         |        187.41 ns |      3.948 ns |     10.875 ns |        182.21 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 100B         |        734.46 ns |      1.002 ns |      0.782 ns |        734.58 ns |         - |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 128B         |        101.85 ns |      0.120 ns |      0.113 ns |        101.84 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 128B         |        110.58 ns |      0.279 ns |      0.218 ns |        110.54 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128B         |        127.63 ns |      0.256 ns |      0.239 ns |        127.69 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 128B         |        128.59 ns |      2.375 ns |      2.106 ns |        128.89 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 128B         |        181.23 ns |      0.372 ns |      0.348 ns |        181.28 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128B         |        734.67 ns |      1.574 ns |      1.472 ns |        734.58 ns |         - |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 137B         |        149.65 ns |      0.354 ns |      0.331 ns |        149.77 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 137B         |        167.87 ns |      0.490 ns |      0.459 ns |        167.90 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 137B         |        186.19 ns |      1.237 ns |      1.157 ns |        185.79 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 137B         |        186.31 ns |      3.015 ns |      2.820 ns |        185.69 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 137B         |        305.27 ns |      2.947 ns |      2.757 ns |        304.94 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 137B         |      1,094.37 ns |      3.079 ns |      2.880 ns |      1,093.55 ns |         - |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1000B        |        779.28 ns |      0.543 ns |      0.454 ns |        779.27 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1000B        |        900.37 ns |      0.293 ns |      0.274 ns |        900.48 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1000B        |        911.54 ns |      0.809 ns |      0.756 ns |        911.57 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1000B        |        971.58 ns |      0.698 ns |      0.653 ns |        971.63 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1000B        |      1,841.27 ns |     10.807 ns |     10.109 ns |      1,844.36 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1000B        |      5,505.62 ns |      6.281 ns |      5.875 ns |      5,508.30 ns |         - |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1KB          |        788.59 ns |      2.520 ns |      2.234 ns |        789.37 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1KB          |        901.80 ns |      4.375 ns |      4.092 ns |        899.92 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1KB          |        925.35 ns |      2.028 ns |      1.897 ns |        925.22 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1KB          |        983.29 ns |      2.286 ns |      2.138 ns |        982.74 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1KB          |      1,755.15 ns |      5.890 ns |      5.221 ns |      1,754.08 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1KB          |      6,781.35 ns |    476.105 ns |  1,366.035 ns |      6,265.62 ns |         - |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1025B        |        889.66 ns |      1.481 ns |      1.385 ns |        889.56 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1025B        |      1,037.41 ns |      2.419 ns |      2.262 ns |      1,037.02 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1025B        |      1,051.79 ns |      2.451 ns |      2.293 ns |      1,052.34 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1025B        |      1,154.94 ns |      5.681 ns |      5.314 ns |      1,154.04 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1025B        |      2,134.13 ns |      3.573 ns |      3.342 ns |      2,134.03 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1025B        |      6,286.81 ns |     12.778 ns |     11.952 ns |      6,289.07 ns |      56 B |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 2KB          |      1,628.96 ns |     12.805 ns |     11.977 ns |      1,621.17 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 2KB          |      1,897.58 ns |      3.858 ns |      3.609 ns |      1,897.75 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 2KB          |      1,904.19 ns |      8.520 ns |      7.553 ns |      1,900.83 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 2KB          |      2,092.01 ns |      7.304 ns |      6.832 ns |      2,094.12 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 2KB          |      2,131.19 ns |      5.064 ns |      4.737 ns |      2,130.55 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 2KB          |     11,445.49 ns |     68.679 ns |     60.882 ns |     11,417.00 ns |      56 B |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 4KB          |      1,805.47 ns |      0.663 ns |      0.588 ns |      1,805.63 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 4KB          |      2,055.52 ns |      1.148 ns |      1.074 ns |      2,055.64 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 4KB          |      2,304.63 ns |      6.267 ns |      5.862 ns |      2,302.94 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 4KB          |      3,158.89 ns |      5.542 ns |      5.184 ns |      3,161.27 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 4KB          |      3,858.87 ns |     10.812 ns |      9.584 ns |      3,862.32 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 4KB          |     23,110.83 ns |    301.134 ns |    281.681 ns |     23,019.98 ns |     168 B |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 6KB          |      3,420.74 ns |      7.060 ns |      6.604 ns |      3,423.31 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 6KB          |      3,973.51 ns |      2.561 ns |      2.396 ns |      3,974.38 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 6KB          |      4,257.54 ns |      9.025 ns |      8.442 ns |      4,259.79 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 6KB          |      4,432.81 ns |      4.038 ns |      3.777 ns |      4,433.62 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 6KB          |      5,739.14 ns |      3.168 ns |      2.809 ns |      5,739.62 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 6KB          |     34,490.89 ns |     66.077 ns |     61.809 ns |     34,519.68 ns |     280 B |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 8KB          |      3,508.55 ns |      6.092 ns |      5.698 ns |      3,510.38 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 8KB          |      4,014.48 ns |      5.967 ns |      5.581 ns |      4,016.85 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 8KB          |      4,552.06 ns |     13.454 ns |     12.584 ns |      4,549.34 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 8KB          |      5,353.28 ns |      6.726 ns |      6.291 ns |      5,354.65 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 8KB          |      7,668.99 ns |      7.566 ns |      7.077 ns |      7,671.95 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 8KB          |     46,132.29 ns |     58.238 ns |     54.476 ns |     46,158.89 ns |     392 B |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 10000B       |      4,955.98 ns |     19.819 ns |     18.539 ns |      4,950.89 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 10000B       |      5,767.93 ns |      5.331 ns |      4.987 ns |      5,766.96 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 10000B       |      6,268.19 ns |      8.448 ns |      7.902 ns |      6,268.42 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 10000B       |      7,884.72 ns |     35.695 ns |     33.389 ns |      7,868.58 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 10000B       |      9,443.96 ns |      4.576 ns |      4.057 ns |      9,445.44 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 10000B       |     56,603.65 ns |     37.189 ns |     34.787 ns |     56,612.84 ns |     504 B |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 64KB         |     27,669.98 ns |     34.451 ns |     32.226 ns |     27,673.82 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 64KB         |     31,571.36 ns |     65.714 ns |     61.469 ns |     31,572.40 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 64KB         |     35,868.37 ns |     57.109 ns |     53.420 ns |     35,855.77 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 64KB         |     36,501.75 ns |     86.136 ns |     76.357 ns |     36,513.38 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 64KB         |     61,737.59 ns |     34.737 ns |     32.493 ns |     61,751.73 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 64KB         |    369,478.56 ns |    590.894 ns |    552.723 ns |    369,620.00 ns |    3528 B |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 100000B      |     42,806.38 ns |     91.246 ns |     85.351 ns |     42,798.57 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 100000B      |     48,938.30 ns |     56.423 ns |     52.778 ns |     48,945.31 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 100000B      |     54,102.55 ns |    107.111 ns |    100.191 ns |     54,137.89 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 100000B      |     54,448.50 ns |    135.880 ns |    127.103 ns |     54,458.35 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 100000B      |     94,316.28 ns |     74.307 ns |     69.507 ns |     94,345.52 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 100000B      |    564,638.82 ns |    383.190 ns |    339.688 ns |    564,705.08 ns |    5432 B |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 128KB        |     55,250.30 ns |     72.120 ns |     67.461 ns |     55,247.16 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 128KB        |     63,098.43 ns |     62.938 ns |     58.872 ns |     63,084.44 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 128KB        |     69,731.01 ns |    152.175 ns |    142.345 ns |     69,713.79 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 128KB        |     70,850.24 ns |    104.837 ns |     98.064 ns |     70,819.50 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128KB        |    123,709.88 ns |     36.656 ns |     34.288 ns |    123,702.95 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128KB        |    739,929.62 ns |    800.367 ns |    748.664 ns |    740,205.57 ns |    7112 B |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 256KB        |    110,645.04 ns |    222.533 ns |    208.157 ns |    110,602.72 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 256KB        |    126,236.87 ns |    131.802 ns |    123.288 ns |    126,224.11 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 256KB        |    136,348.86 ns |    394.809 ns |    369.305 ns |    136,341.57 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 256KB        |    140,876.76 ns |    290.339 ns |    271.583 ns |    140,837.08 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 256KB        |    248,228.60 ns |     91.871 ns |     85.936 ns |    248,240.64 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 256KB        |  1,480,403.24 ns |    977.493 ns |    914.348 ns |  1,480,678.96 ns |   14280 B |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 512KB        |    221,512.97 ns |    431.351 ns |    403.486 ns |    221,541.85 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 512KB        |    252,536.66 ns |    240.348 ns |    200.701 ns |    252,503.19 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 512KB        |    269,203.54 ns |  1,078.478 ns |    842.004 ns |    268,935.70 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 512KB        |    280,783.16 ns |    540.553 ns |    505.633 ns |    280,807.72 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 512KB        |    499,686.78 ns |  7,015.134 ns |  6,561.961 ns |    496,642.58 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 512KB        |  2,961,589.14 ns |  1,497.069 ns |  1,400.360 ns |  2,961,651.20 ns |   28616 B |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1MB          |    421,864.63 ns |    951.120 ns |    889.678 ns |    421,803.77 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1MB          |    481,893.88 ns |    424.981 ns |    397.528 ns |    481,906.87 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1MB          |    508,442.63 ns |  1,303.776 ns |  1,155.763 ns |    508,141.05 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1MB          |    533,749.34 ns |  1,135.139 ns |  1,061.810 ns |    533,296.63 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1MB          |    946,965.73 ns |    596.363 ns |    557.838 ns |    946,972.86 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1MB          |  5,667,507.42 ns |  3,066.805 ns |  2,718.642 ns |  5,667,689.95 ns |   54656 B |
|                                              |              |                  |               |               |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 10MB         |  4,228,962.07 ns | 12,740.249 ns | 11,293.899 ns |  4,225,894.52 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 10MB         |  4,816,838.24 ns |  4,515.904 ns |  4,003.231 ns |  4,818,575.03 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 10MB         |  5,073,768.08 ns | 12,494.127 ns | 11,687.014 ns |  5,073,037.77 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 10MB         |  5,328,239.52 ns | 12,762.616 ns | 11,938.159 ns |  5,329,460.94 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 10MB         |  9,474,419.84 ns |  5,338.100 ns |  4,993.262 ns |  9,475,467.45 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 10MB         | 56,671,682.87 ns | 22,691.360 ns | 20,115.300 ns | 56,677,018.50 ns |  546840 B |