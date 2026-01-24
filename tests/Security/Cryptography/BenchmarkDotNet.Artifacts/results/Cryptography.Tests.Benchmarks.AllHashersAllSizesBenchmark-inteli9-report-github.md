```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26100.7623/24H2/2024Update/HudsonValley)
Intel Core i9-10900 CPU 2.80GHz (Max: 2.81GHz), 1 CPU, 20 logical and 10 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                                | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|----------------------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| **ComputeHash | BLAKE2b-512 | BouncyCastle**                   | **128B**         |       **172.8 ns** |      **3.50 ns** |      **4.03 ns** |     **176 B** |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2           | 128B         |       399.6 ns |      6.20 ns |      5.80 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar         | 128B         |       566.4 ns |      3.99 ns |      3.53 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                   | 137B         |       266.4 ns |      2.65 ns |      2.35 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2           | 137B         |       728.6 ns |     11.40 ns |     10.66 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar         | 137B         |     1,040.0 ns |      2.55 ns |      2.26 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                   | 1KB          |       781.9 ns |      4.09 ns |      3.63 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2           | 1KB          |     2,620.2 ns |     29.73 ns |     27.81 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar         | 1KB          |     3,987.4 ns |     78.46 ns |     80.58 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                   | 1025B        |       875.0 ns |      3.85 ns |      3.41 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2           | 1025B        |     2,992.6 ns |     22.82 ns |     20.23 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar         | 1025B        |     4,465.3 ns |     71.04 ns |     72.95 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                   | 8KB          |     5,650.3 ns |     20.77 ns |     18.41 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2           | 8KB          |    20,135.3 ns |    129.12 ns |    120.78 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar         | 8KB          |    31,098.7 ns |    584.65 ns |    546.88 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                   | 128KB        |    90,131.8 ns |    212.59 ns |    177.52 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2           | 128KB        |   327,690.6 ns |  2,955.58 ns |  2,620.04 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar         | 128KB        |   496,092.5 ns |  9,608.28 ns |  9,436.62 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle                   | 128B         |       224.2 ns |      4.32 ns |      4.04 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2           | 128B         |       262.6 ns |      1.44 ns |      1.20 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Ssse3          | 128B         |       265.7 ns |      5.29 ns |      6.88 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2           | 128B         |       571.7 ns |      2.48 ns |      2.20 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar         | 128B         |       891.2 ns |      7.57 ns |      7.08 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle                   | 137B         |       294.9 ns |      3.61 ns |      3.37 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Ssse3          | 137B         |       341.7 ns |      2.28 ns |      2.02 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2           | 137B         |       352.8 ns |      1.90 ns |      1.59 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2           | 137B         |       819.3 ns |      3.04 ns |      2.69 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar         | 137B         |     1,291.2 ns |      5.59 ns |      5.23 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle                   | 1KB          |     1,227.7 ns |      9.98 ns |      9.34 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Ssse3          | 1KB          |     1,486.2 ns |      4.36 ns |      3.64 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2           | 1KB          |     1,555.8 ns |      7.27 ns |      6.44 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2           | 1KB          |     4,215.9 ns |     60.09 ns |     56.20 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar         | 1KB          |     6,653.7 ns |    105.73 ns |     98.90 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle                   | 1025B        |     1,293.8 ns |     14.18 ns |     12.57 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Ssse3          | 1025B        |     1,600.5 ns |     31.22 ns |     29.21 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2           | 1025B        |     1,648.9 ns |      5.38 ns |      5.04 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2           | 1025B        |     4,405.7 ns |     36.13 ns |     32.03 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar         | 1025B        |     6,971.9 ns |     59.43 ns |     55.60 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle                   | 8KB          |     9,163.9 ns |     34.19 ns |     28.55 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Ssse3          | 8KB          |    11,349.6 ns |     77.33 ns |     64.57 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2           | 8KB          |    12,043.1 ns |    214.15 ns |    200.32 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2           | 8KB          |    32,696.6 ns |    153.09 ns |    135.71 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar         | 8KB          |    51,449.1 ns |    143.90 ns |    120.16 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle                   | 128KB        |   145,860.8 ns |    635.46 ns |    563.31 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Ssse3          | 128KB        |   180,102.2 ns |    660.40 ns |    585.43 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2           | 128KB        |   191,794.9 ns |  3,355.94 ns |  2,974.95 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2           | 128KB        |   532,663.5 ns | 10,456.04 ns |  9,269.01 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar         | 128KB        |   832,731.4 ns | 11,296.98 ns | 10,567.20 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | BLAKE3 | Native                              | 128B         |       146.4 ns |      0.75 ns |      0.70 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                | 128B         |       499.8 ns |      3.29 ns |      2.92 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar               | 128B         |       796.0 ns |     15.71 ns |     16.14 ns |     112 B |
| ComputeHash | BLAKE3 | BouncyCastle                        | 128B         |       998.1 ns |      4.46 ns |      3.95 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | BLAKE3 | Native                              | 137B         |       187.9 ns |      0.86 ns |      0.76 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                | 137B         |       568.0 ns |      6.60 ns |      6.18 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar               | 137B         |     1,111.3 ns |      5.28 ns |      4.12 ns |     112 B |
| ComputeHash | BLAKE3 | BouncyCastle                        | 137B         |     1,533.4 ns |      5.88 ns |      4.91 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | BLAKE3 | Native                              | 1KB          |       764.9 ns |      9.96 ns |      8.83 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                | 1KB          |     1,404.7 ns |     27.25 ns |     25.49 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar               | 1KB          |     5,497.9 ns |     65.73 ns |     58.27 ns |     112 B |
| ComputeHash | BLAKE3 | BouncyCastle                        | 1KB          |     7,575.3 ns |     37.19 ns |     32.97 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | BLAKE3 | Native                              | 1025B        |       882.3 ns |     13.17 ns |     11.67 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                | 1025B        |     1,596.0 ns |     11.84 ns |     10.50 ns |     224 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar               | 1025B        |     6,249.5 ns |     54.38 ns |     45.41 ns |     224 B |
| ComputeHash | BLAKE3 | BouncyCastle                        | 1025B        |     8,835.6 ns |    170.96 ns |    167.91 ns |     168 B |
|                                                            |              |                |              |              |           |
| ComputeHash | BLAKE3 | Native                              | 8KB          |     1,763.3 ns |      5.99 ns |      4.68 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                | 8KB          |    11,262.2 ns |    136.57 ns |    127.75 ns |     896 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar               | 8KB          |    46,375.0 ns |    562.38 ns |    498.54 ns |     896 B |
| ComputeHash | BLAKE3 | BouncyCastle                        | 8KB          |    63,930.0 ns |    578.22 ns |    512.58 ns |     504 B |
|                                                            |              |                |              |              |           |
| ComputeHash | BLAKE3 | Native                              | 128KB        |    26,171.7 ns |    409.20 ns |    382.77 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                | 128KB        |   185,522.9 ns |  3,565.41 ns |  3,335.09 ns |   14336 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar               | 128KB        |   742,645.3 ns |  5,841.64 ns |  4,878.04 ns |   14336 B |
| ComputeHash | BLAKE3 | BouncyCastle                        | 128KB        | 1,026,440.3 ns | 13,506.68 ns | 12,634.16 ns |    7224 B |
|                                                            |              |                |              |              |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar         | 128B         |       448.4 ns |      2.96 ns |      2.47 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                     | 128B         |       500.6 ns |      4.51 ns |      3.99 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2           | 128B         |       508.7 ns |      4.33 ns |      3.83 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar         | 137B         |       437.1 ns |      1.71 ns |      1.33 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                     | 137B         |       504.2 ns |      7.78 ns |      7.28 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2           | 137B         |       504.3 ns |      4.14 ns |      3.67 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar         | 1KB          |     2,324.8 ns |      9.82 ns |      7.67 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                     | 1KB          |     2,864.1 ns |     26.77 ns |     22.35 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2           | 1KB          |     2,864.5 ns |     16.00 ns |     14.97 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar         | 1025B        |     2,317.3 ns |     14.76 ns |     12.32 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2           | 1025B        |     2,846.2 ns |     11.34 ns |      9.47 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                     | 1025B        |     2,868.2 ns |     22.61 ns |     18.88 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar         | 8KB          |    14,007.6 ns |    144.85 ns |    135.50 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2           | 8KB          |    18,238.4 ns |    106.12 ns |     99.27 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                     | 8KB          |    19,150.0 ns |    142.21 ns |    126.07 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar         | 128KB        |   219,099.2 ns |  1,486.63 ns |  1,317.86 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2           | 128KB        |   287,980.1 ns |  4,860.09 ns |  4,546.14 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                     | 128KB        |   301,159.1 ns |  1,338.07 ns |  1,186.16 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar         | 128B         |       445.0 ns |      4.22 ns |      3.53 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                     | 128B         |       498.5 ns |      4.35 ns |      3.85 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2           | 128B         |       516.6 ns |      9.74 ns |      8.63 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | CSHAKE256 | BouncyCastle                     | 137B         |       872.8 ns |      7.80 ns |      6.91 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar         | 137B         |       881.4 ns |      6.90 ns |      5.76 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2           | 137B         |     1,046.0 ns |     18.63 ns |     17.42 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar         | 1KB          |     2,499.0 ns |     16.54 ns |     14.66 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2           | 1KB          |     3,153.5 ns |     43.35 ns |     38.43 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                     | 1KB          |     3,253.1 ns |     48.11 ns |     45.00 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar         | 1025B        |     2,531.6 ns |     43.95 ns |     41.11 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2           | 1025B        |     3,158.3 ns |     47.92 ns |     42.48 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                     | 1025B        |     3,243.6 ns |     22.94 ns |     21.46 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar         | 8KB          |    17,383.7 ns |    225.56 ns |    231.63 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2           | 8KB          |    22,527.0 ns |     95.64 ns |     74.67 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                     | 8KB          |    23,539.6 ns |    202.10 ns |    179.16 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar         | 128KB        |   266,967.4 ns |  1,825.01 ns |  1,707.12 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2           | 128KB        |   351,797.0 ns |  2,887.93 ns |  2,560.08 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                     | 128KB        |   368,326.3 ns |  2,294.22 ns |  1,915.78 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar        | 128B         |       367.7 ns |      1.99 ns |      1.76 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2          | 128B         |       437.1 ns |      2.40 ns |      1.88 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                    | 128B         |       490.5 ns |      4.88 ns |      4.33 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar        | 137B         |       814.9 ns |      6.56 ns |      5.81 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                    | 137B         |       853.9 ns |      4.50 ns |      3.76 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2          | 137B         |       978.4 ns |     14.22 ns |     13.30 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar        | 1KB          |     2,438.1 ns |     19.21 ns |     17.03 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2          | 1KB          |     3,035.0 ns |     17.72 ns |     15.70 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                    | 1KB          |     3,238.6 ns |     47.67 ns |     42.25 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar        | 1025B        |     2,430.2 ns |     21.16 ns |     17.67 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2          | 1025B        |     3,059.1 ns |     23.38 ns |     20.73 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                    | 1025B        |     3,218.8 ns |     27.76 ns |     23.18 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar        | 8KB          |    17,176.0 ns |    161.03 ns |    142.75 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2          | 8KB          |    22,257.4 ns |    104.16 ns |     92.34 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                    | 8KB          |    23,810.3 ns |    418.75 ns |    498.49 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar        | 128KB        |   267,703.1 ns |  1,879.52 ns |  1,569.49 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2          | 128KB        |   352,920.0 ns |  2,791.47 ns |  2,474.57 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                    | 128KB        |   368,975.9 ns |  1,341.91 ns |  1,189.57 ns |     112 B |
|                                                            |              |                |              |              |           |
| **ComputeHash | KMAC-128 | CryptoHives**                       | **128B**         |     **1,168.9 ns** |     **15.38 ns** |     **14.39 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                         | **128B**         |     **1,690.4 ns** |     **20.87 ns** |     **18.50 ns** |     **296 B** |
| ComputeHash | KMAC-128 | BouncyCastle                      | 128B         |     2,650.0 ns |     17.32 ns |     15.35 ns |     400 B |
|                                                            |              |                |              |              |           |
| **ComputeHash | KMAC-128 | CryptoHives**                       | **137B**         |     **1,148.4 ns** |     **10.41 ns** |      **9.23 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                         | **137B**         |     **1,721.4 ns** |     **33.71 ns** |     **38.82 ns** |     **312 B** |
| ComputeHash | KMAC-128 | BouncyCastle                      | 137B         |     2,674.0 ns |     16.03 ns |     13.39 ns |     400 B |
|                                                            |              |                |              |              |           |
| **ComputeHash | KMAC-128 | CryptoHives**                       | **1KB**          |     **3,049.8 ns** |     **26.98 ns** |     **22.53 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                         | **1KB**          |     **4,163.9 ns** |     **81.88 ns** |     **80.42 ns** |    **1192 B** |
| ComputeHash | KMAC-128 | BouncyCastle                      | 1KB          |     5,039.9 ns |     26.31 ns |     23.32 ns |     400 B |
|                                                            |              |                |              |              |           |
| **ComputeHash | KMAC-128 | CryptoHives**                       | **1025B**        |     **3,038.7 ns** |     **27.34 ns** |     **24.24 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                         | **1025B**        |     **4,134.8 ns** |     **78.22 ns** |     **83.69 ns** |    **1200 B** |
| ComputeHash | KMAC-128 | BouncyCastle                      | 1025B        |     5,099.2 ns |     96.36 ns |     85.42 ns |     400 B |
|                                                            |              |                |              |              |           |
| **ComputeHash | KMAC-128 | CryptoHives**                       | **8KB**          |    **14,694.3 ns** |     **76.56 ns** |     **63.93 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | BouncyCastle**                      | **8KB**          |    **21,661.4 ns** |    **409.46 ns** |    **383.01 ns** |     **400 B** |
| ComputeHash | KMAC-128 | OS Native                         | 8KB          |    21,729.5 ns |    406.58 ns |    556.54 ns |    8360 B |
|                                                            |              |                |              |              |           |
| **ComputeHash | KMAC-128 | CryptoHives**                       | **128KB**        |   **222,192.3 ns** |  **3,149.78 ns** |  **2,946.31 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | BouncyCastle**                      | **128KB**        |   **302,473.1 ns** |  **2,025.01 ns** |  **1,690.97 ns** |     **400 B** |
| ComputeHash | KMAC-128 | OS Native                         | 128KB        |   356,592.9 ns |  2,088.03 ns |  1,630.20 ns |  131263 B |
|                                                            |              |                |              |              |           |
| **ComputeHash | KMAC-256 | CryptoHives**                       | **128B**         |     **1,158.4 ns** |      **6.49 ns** |      **5.07 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                         | **128B**         |     **1,719.0 ns** |     **33.48 ns** |     **31.31 ns** |     **360 B** |
| ComputeHash | KMAC-256 | BouncyCastle                      | 128B         |     2,633.0 ns |     36.70 ns |     34.33 ns |     464 B |
|                                                            |              |                |              |              |           |
| **ComputeHash | KMAC-256 | CryptoHives**                       | **137B**         |     **1,616.7 ns** |     **30.71 ns** |     **28.73 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                         | **137B**         |     **2,058.4 ns** |     **10.73 ns** |     **10.04 ns** |     **376 B** |
| ComputeHash | KMAC-256 | BouncyCastle                      | 137B         |     2,984.4 ns |     44.03 ns |     39.03 ns |     464 B |
|                                                            |              |                |              |              |           |
| **ComputeHash | KMAC-256 | CryptoHives**                       | **1KB**          |     **3,224.3 ns** |     **14.31 ns** |     **11.17 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                         | **1KB**          |     **4,422.6 ns** |     **32.71 ns** |     **27.31 ns** |    **1256 B** |
| ComputeHash | KMAC-256 | BouncyCastle                      | 1KB          |     5,429.0 ns |     87.83 ns |     82.15 ns |     464 B |
|                                                            |              |                |              |              |           |
| **ComputeHash | KMAC-256 | CryptoHives**                       | **1025B**        |     **3,233.3 ns** |     **21.96 ns** |     **18.34 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                         | **1025B**        |     **4,451.2 ns** |     **40.08 ns** |     **33.47 ns** |    **1264 B** |
| ComputeHash | KMAC-256 | BouncyCastle                      | 1025B        |     5,515.9 ns |    107.82 ns |    110.72 ns |     464 B |
|                                                            |              |                |              |              |           |
| **ComputeHash | KMAC-256 | CryptoHives**                       | **8KB**          |    **17,964.6 ns** |     **70.64 ns** |     **58.99 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                         | **8KB**          |    **25,522.7 ns** |    **436.85 ns** |    **408.63 ns** |    **8424 B** |
| ComputeHash | KMAC-256 | BouncyCastle                      | 8KB          |    25,584.2 ns |    139.04 ns |    108.55 ns |     464 B |
|                                                            |              |                |              |              |           |
| **ComputeHash | KMAC-256 | CryptoHives**                       | **128KB**        |   **267,484.2 ns** |  **1,947.00 ns** |  **1,625.84 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | BouncyCastle**                      | **128KB**        |   **372,824.8 ns** |  **4,059.10 ns** |  **3,796.88 ns** |     **464 B** |
| ComputeHash | KMAC-256 | OS Native                         | 128KB        |   424,964.1 ns |  5,624.47 ns |  5,261.13 ns |  131327 B |
|                                                            |              |                |              |              |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                 | 128B         |       370.1 ns |      2.22 ns |      1.97 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                   | 128B         |       397.4 ns |      6.76 ns |      5.99 ns |     584 B |
|                                                            |              |                |              |              |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                 | 137B         |       362.6 ns |      2.09 ns |      1.74 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                   | 137B         |       383.7 ns |      5.43 ns |      4.24 ns |     584 B |
|                                                            |              |                |              |              |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                 | 1KB          |     1,457.6 ns |      5.61 ns |      4.68 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                   | 1KB          |     1,711.0 ns |      3.84 ns |      3.00 ns |     584 B |
|                                                            |              |                |              |              |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                 | 1025B        |     1,464.9 ns |     20.41 ns |     18.09 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                   | 1025B        |     1,715.4 ns |     11.32 ns |     10.03 ns |     584 B |
|                                                            |              |                |              |              |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                 | 8KB          |     9,059.2 ns |     74.91 ns |     66.41 ns |    1056 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                   | 8KB          |    11,046.5 ns |     71.22 ns |     63.13 ns |    1056 B |
|                                                            |              |                |              |              |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                 | 128KB        |   126,932.1 ns |    873.61 ns |    729.50 ns |    8136 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                   | 128KB        |   160,207.4 ns |  1,194.26 ns |  1,058.68 ns |    8136 B |
|                                                            |              |                |              |              |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                 | 128B         |       377.3 ns |      2.39 ns |      2.00 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                   | 128B         |       397.4 ns |      3.45 ns |      3.06 ns |     616 B |
|                                                            |              |                |              |              |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                 | 137B         |       684.8 ns |      4.10 ns |      3.20 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                   | 137B         |       740.3 ns |      3.97 ns |      3.31 ns |     616 B |
|                                                            |              |                |              |              |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                 | 1KB          |     1,578.6 ns |     11.37 ns |      9.49 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                   | 1KB          |     1,825.8 ns |     15.36 ns |     14.36 ns |     616 B |
|                                                            |              |                |              |              |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                 | 1025B        |     1,585.5 ns |     12.41 ns |     10.36 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                   | 1025B        |     1,818.1 ns |      7.27 ns |      6.07 ns |     616 B |
|                                                            |              |                |              |              |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                 | 8KB          |    10,394.8 ns |     97.96 ns |     81.80 ns |    1056 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                   | 8KB          |    13,053.2 ns |    203.76 ns |    170.15 ns |    1056 B |
|                                                            |              |                |              |              |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                 | 128KB        |   157,020.5 ns |  1,164.60 ns |  1,032.39 ns |    7656 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                   | 128KB        |   198,059.9 ns |  1,321.07 ns |  1,171.09 ns |    7656 B |
|                                                            |              |                |              |              |           |
| ComputeHash | MD5 | OS Native                              | 128B         |       391.4 ns |      1.50 ns |      1.17 ns |      80 B |
| ComputeHash | MD5 | BouncyCastle                           | 128B         |       480.3 ns |      4.32 ns |      4.04 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                            | **128B**         |       **549.3 ns** |      **4.33 ns** |      **3.84 ns** |      **80 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | MD5 | OS Native**                              | **137B**         |       **391.2 ns** |      **5.36 ns** |      **4.47 ns** |      **80 B** |
| ComputeHash | MD5 | BouncyCastle                           | 137B         |       479.9 ns |      4.50 ns |      3.99 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                            | **137B**         |       **568.4 ns** |      **6.92 ns** |      **6.13 ns** |      **80 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | MD5 | OS Native**                              | **1KB**          |     **1,685.1 ns** |     **14.28 ns** |     **12.66 ns** |      **80 B** |
| ComputeHash | MD5 | BouncyCastle                           | 1KB          |     2,437.5 ns |     12.94 ns |     11.47 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                            | **1KB**          |     **2,871.7 ns** |     **16.52 ns** |     **13.79 ns** |      **80 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | MD5 | OS Native**                              | **1025B**        |     **1,693.1 ns** |     **17.72 ns** |     **16.57 ns** |      **80 B** |
| ComputeHash | MD5 | BouncyCastle                           | 1025B        |     2,447.1 ns |     15.89 ns |     13.27 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                            | **1025B**        |     **2,839.4 ns** |     **34.77 ns** |     **30.82 ns** |      **80 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | MD5 | OS Native**                              | **8KB**          |    **11,723.6 ns** |     **76.03 ns** |     **67.40 ns** |      **80 B** |
| ComputeHash | MD5 | BouncyCastle                           | 8KB          |    17,741.6 ns |    147.99 ns |    131.19 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                            | **8KB**          |    **21,486.3 ns** |    **356.66 ns** |    **333.62 ns** |      **80 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | MD5 | OS Native**                              | **128KB**        |   **182,406.7 ns** |    **385.64 ns** |    **301.08 ns** |      **80 B** |
| ComputeHash | MD5 | BouncyCastle                           | 128KB        |   278,203.2 ns |    669.65 ns |    559.19 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                            | **128KB**        |   **331,259.2 ns** |  **1,575.79 ns** |  **1,315.85 ns** |      **80 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                    | **128B**         |       **740.9 ns** |      **3.76 ns** |      **3.14 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                     | **128B**         |     **1,606.9 ns** |     **11.40 ns** |      **9.52 ns** |      **96 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                    | **137B**         |       **740.8 ns** |      **4.44 ns** |      **3.71 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                     | **137B**         |     **1,615.0 ns** |     **15.43 ns** |     **13.68 ns** |      **96 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                    | **1KB**          |     **3,906.4 ns** |     **26.42 ns** |     **23.42 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                     | **1KB**          |     **8,920.3 ns** |     **44.53 ns** |     **37.18 ns** |      **96 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                    | **1025B**        |     **3,905.4 ns** |     **23.72 ns** |     **19.81 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                     | **1025B**        |     **8,748.7 ns** |     **70.48 ns** |     **62.48 ns** |      **96 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                    | **8KB**          |    **29,149.1 ns** |    **285.23 ns** |    **238.18 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                     | **8KB**          |    **65,538.5 ns** |    **348.85 ns** |    **291.30 ns** |      **96 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                    | **128KB**        |   **460,328.3 ns** |  **4,671.01 ns** |  **4,140.73 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                     | **128KB**        | **1,044,928.1 ns** |  **7,197.03 ns** |  **6,379.98 ns** |      **96 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-1 | OS Native**                            | **128B**         |       **383.1 ns** |      **2.49 ns** |      **2.21 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                         | 128B         |       681.8 ns |      5.11 ns |      4.27 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                          | **128B**         |       **769.4 ns** |     **11.50 ns** |     **10.76 ns** |      **96 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-1 | OS Native**                            | **137B**         |       **379.4 ns** |      **4.13 ns** |      **3.66 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                         | 137B         |       689.2 ns |      8.75 ns |      7.75 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                          | **137B**         |       **753.3 ns** |      **5.56 ns** |      **4.65 ns** |      **96 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-1 | OS Native**                            | **1KB**          |     **1,533.5 ns** |      **5.44 ns** |      **4.25 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                         | 1KB          |     3,490.3 ns |     27.97 ns |     24.79 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                          | **1KB**          |     **3,748.0 ns** |     **20.42 ns** |     **18.10 ns** |      **96 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-1 | OS Native**                            | **1025B**        |     **1,549.6 ns** |     **10.50 ns** |      **8.77 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                         | 1025B        |     3,460.9 ns |     13.01 ns |     10.86 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                          | **1025B**        |     **3,738.8 ns** |     **28.20 ns** |     **25.00 ns** |      **96 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-1 | OS Native**                            | **8KB**          |    **10,393.0 ns** |     **76.91 ns** |     **68.18 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                         | 8KB          |    25,801.5 ns |    101.48 ns |     89.96 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                          | **8KB**          |    **27,527.3 ns** |    **535.60 ns** |    **474.79 ns** |      **96 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-1 | OS Native**                            | **128KB**        |   **163,269.7 ns** |  **1,705.96 ns** |  **1,512.29 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                         | 128KB        |   407,621.1 ns |  2,244.61 ns |  1,989.78 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                          | **128KB**        |   **428,876.5 ns** |  **1,670.59 ns** |  **1,395.02 ns** |      **96 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-224 | BouncyCastle**                       | **128B**         |       **855.1 ns** |     **10.66 ns** |      **8.91 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                        | **128B**         |       **940.7 ns** |      **7.36 ns** |      **6.14 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-224 | BouncyCastle**                       | **137B**         |       **857.5 ns** |      **3.54 ns** |      **2.76 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                        | **137B**         |       **936.2 ns** |      **3.62 ns** |      **3.21 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-224 | BouncyCastle**                       | **1KB**          |     **4,422.3 ns** |     **35.93 ns** |     **31.86 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                        | **1KB**          |     **4,633.0 ns** |     **23.91 ns** |     **19.97 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-224 | BouncyCastle**                       | **1025B**        |     **4,441.7 ns** |     **49.20 ns** |     **43.61 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                        | **1025B**        |     **4,637.5 ns** |     **31.28 ns** |     **26.12 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-224 | BouncyCastle**                       | **8KB**          |    **33,666.9 ns** |    **556.93 ns** |    **520.95 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                        | **8KB**          |    **38,130.1 ns** |    **756.23 ns** |    **840.54 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-224 | BouncyCastle**                       | **128KB**        |   **521,530.0 ns** |  **3,617.52 ns** |  **3,020.80 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                        | **128KB**        |   **557,230.0 ns** |  **9,882.30 ns** | **10,573.95 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-256 | OS Native**                          | **128B**         |       **536.3 ns** |      **5.61 ns** |      **4.68 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                       | 128B         |       872.6 ns |     16.40 ns |     15.34 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                        | **128B**         |       **948.4 ns** |      **7.10 ns** |      **5.55 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-256 | OS Native**                          | **137B**         |       **547.2 ns** |     **10.73 ns** |     **14.69 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                       | 137B         |       888.8 ns |      9.86 ns |      8.74 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                        | **137B**         |       **979.8 ns** |     **12.36 ns** |     **11.57 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-256 | OS Native**                          | **1KB**          |     **2,418.5 ns** |     **47.35 ns** |     **52.62 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                       | 1KB          |     4,475.6 ns |     84.67 ns |     83.16 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                        | **1KB**          |     **4,921.4 ns** |     **67.62 ns** |     **63.26 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-256 | OS Native**                          | **1025B**        |     **2,348.1 ns** |     **27.96 ns** |     **26.16 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                       | 1025B        |     4,589.7 ns |     89.06 ns |    118.90 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                        | **1025B**        |     **4,800.2 ns** |     **59.81 ns** |     **49.95 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-256 | OS Native**                          | **8KB**          |    **16,148.5 ns** |    **245.30 ns** |    **229.46 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                       | 8KB          |    32,970.3 ns |    537.39 ns |    448.74 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                        | **8KB**          |    **35,557.5 ns** |    **513.04 ns** |    **479.90 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-256 | OS Native**                          | **128KB**        |   **248,554.3 ns** |  **3,490.10 ns** |  **3,264.64 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                       | 128KB        |   515,275.7 ns |  9,264.80 ns |  8,666.30 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                        | **128KB**        |   **560,348.0 ns** |  **8,189.84 ns** |  **7,660.79 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-384 | OS Native**                          | **128B**         |       **603.6 ns** |      **8.56 ns** |      **8.01 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                       | 128B         |       686.0 ns |      3.68 ns |      3.27 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                        | **128B**         |       **868.4 ns** |      **9.25 ns** |      **8.20 ns** |     **144 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-384 | OS Native**                          | **137B**         |       **608.8 ns** |      **9.55 ns** |      **7.97 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                       | 137B         |       694.4 ns |      3.29 ns |      2.92 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                        | **137B**         |       **867.3 ns** |     **12.93 ns** |     **10.80 ns** |     **144 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-384 | OS Native**                          | **1KB**          |     **2,188.7 ns** |     **14.30 ns** |     **11.16 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                       | 1KB          |     2,805.5 ns |     30.91 ns |     28.91 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                        | **1KB**          |     **3,124.6 ns** |     **59.19 ns** |     **55.36 ns** |     **144 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-384 | OS Native**                          | **1025B**        |     **2,198.3 ns** |     **18.91 ns** |     **15.79 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                       | 1025B        |     2,815.8 ns |     41.70 ns |     39.00 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                        | **1025B**        |     **3,131.5 ns** |     **61.01 ns** |     **57.07 ns** |     **144 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-384 | OS Native**                          | **8KB**          |    **14,752.6 ns** |    **279.50 ns** |    **299.06 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                       | 8KB          |    19,767.7 ns |    373.46 ns |    349.34 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                        | **8KB**          |    **21,012.4 ns** |    **371.45 ns** |    **364.82 ns** |     **144 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-384 | OS Native**                          | **128KB**        |   **230,208.1 ns** |  **2,869.77 ns** |  **2,543.98 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                       | 128KB        |   315,389.0 ns |  6,214.04 ns |  7,631.39 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                        | **128KB**        |   **328,816.0 ns** |  **4,332.52 ns** |  **3,840.67 ns** |     **144 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-512 | OS Native**                          | **128B**         |       **605.3 ns** |     **11.33 ns** |     **10.60 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                       | 128B         |       702.5 ns |     13.50 ns |     14.44 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                        | **128B**         |       **968.9 ns** |     **18.61 ns** |     **17.41 ns** |     **176 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-512 | OS Native**                          | **137B**         |       **602.3 ns** |     **11.11 ns** |      **9.85 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                       | 137B         |       709.8 ns |     12.15 ns |     11.36 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                        | **137B**         |       **968.9 ns** |     **18.66 ns** |     **19.97 ns** |     **176 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-512 | OS Native**                          | **1KB**          |     **2,244.4 ns** |     **36.16 ns** |     **33.83 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                       | 1KB          |     2,973.4 ns |     57.13 ns |     70.17 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                        | **1KB**          |     **3,507.2 ns** |     **69.95 ns** |     **77.75 ns** |     **176 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-512 | OS Native**                          | **1025B**        |     **2,284.8 ns** |     **35.09 ns** |     **31.10 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                       | 1025B        |     2,894.6 ns |     25.41 ns |     21.22 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                        | **1025B**        |     **3,580.5 ns** |     **69.89 ns** |     **65.38 ns** |     **176 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-512 | OS Native**                          | **8KB**          |    **15,056.2 ns** |     **90.92 ns** |     **80.59 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                       | 8KB          |    21,008.3 ns |    242.58 ns |    226.91 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                        | **8KB**          |    **24,101.3 ns** |    **330.90 ns** |    **293.33 ns** |     **176 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-512 | OS Native**                          | **128KB**        |   **222,293.9 ns** |  **1,610.61 ns** |  **1,427.76 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                       | 128KB        |   303,116.3 ns |  2,539.51 ns |  2,120.60 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                        | **128KB**        |   **352,432.4 ns** |  **2,569.98 ns** |  **2,278.22 ns** |     **176 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**                   | **128B**         |       **685.5 ns** |      **3.78 ns** |      **3.35 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**                    | **128B**         |       **860.2 ns** |     **14.67 ns** |     **13.01 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**                   | **137B**         |       **692.6 ns** |      **3.97 ns** |      **3.52 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**                    | **137B**         |       **839.6 ns** |      **8.08 ns** |      **7.16 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**                   | **1KB**          |     **2,746.3 ns** |     **14.10 ns** |     **11.78 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**                    | **1KB**          |     **3,003.1 ns** |     **12.66 ns** |     **10.57 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**                   | **1025B**        |     **2,796.1 ns** |     **52.55 ns** |     **51.61 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**                    | **1025B**        |     **3,004.0 ns** |     **10.07 ns** |      **8.92 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**                   | **8KB**          |    **19,310.8 ns** |    **351.40 ns** |    **328.70 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**                    | **8KB**          |    **20,416.0 ns** |    **399.40 ns** |    **373.60 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**                   | **128KB**        |   **302,643.0 ns** |  **3,651.12 ns** |  **3,415.26 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**                    | **128KB**        |   **317,468.6 ns** |  **4,610.37 ns** |  **3,849.87 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-512/256 | BouncyCastle**                   | **128B**         |       **698.2 ns** |      **9.31 ns** |      **7.77 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | CryptoHives**                    | **128B**         |       **848.1 ns** |      **6.51 ns** |      **5.43 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-512/256 | BouncyCastle**                   | **137B**         |       **696.7 ns** |      **5.49 ns** |      **4.58 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | CryptoHives**                    | **137B**         |       **836.9 ns** |      **2.86 ns** |      **2.39 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-512/256 | BouncyCastle**                   | **1KB**          |     **2,756.0 ns** |     **16.03 ns** |     **14.21 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | CryptoHives**                    | **1KB**          |     **3,051.7 ns** |     **61.04 ns** |     **57.10 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-512/256 | BouncyCastle**                   | **1025B**        |     **2,767.4 ns** |     **15.64 ns** |     **13.06 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | CryptoHives**                    | **1025B**        |     **3,020.7 ns** |     **13.52 ns** |     **11.98 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-512/256 | BouncyCastle**                   | **8KB**          |    **19,259.6 ns** |    **175.53 ns** |    **146.57 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | CryptoHives**                    | **8KB**          |    **20,247.4 ns** |    **158.12 ns** |    **140.17 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA-512/256 | BouncyCastle**                   | **128KB**        |   **300,336.8 ns** |  **1,048.97 ns** |    **875.94 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | CryptoHives**                    | **128KB**        |   **322,552.0 ns** |  **4,206.03 ns** |  **3,512.22 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar**           | **128B**         |       **380.7 ns** |      **3.49 ns** |      **3.27 ns** |     **112 B** |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2             | 128B         |       444.4 ns |      3.29 ns |      2.92 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                      | 128B         |       485.7 ns |      2.47 ns |      2.19 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar           | 137B         |       370.3 ns |      1.45 ns |      1.13 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2             | 137B         |       427.8 ns |      0.75 ns |      0.67 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                      | 137B         |       489.5 ns |      1.09 ns |      0.97 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar           | 1KB          |     2,528.8 ns |     23.28 ns |     21.78 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2             | 1KB          |     3,116.4 ns |      9.15 ns |      8.56 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                      | 1KB          |     3,215.5 ns |     21.34 ns |     19.96 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar           | 1025B        |     2,532.2 ns |     16.56 ns |     14.68 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2             | 1025B        |     3,161.8 ns |     48.91 ns |     45.75 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                      | 1025B        |     3,225.6 ns |      9.06 ns |      8.47 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar           | 8KB          |    15,976.6 ns |     71.64 ns |     59.82 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2             | 8KB          |    20,783.0 ns |     81.87 ns |     72.57 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                      | 8KB          |    22,241.6 ns |    113.99 ns |    106.62 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar           | 128KB        |   252,581.5 ns |  1,152.07 ns |    962.03 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2             | 128KB        |   329,625.9 ns |    527.89 ns |    412.15 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                      | 128KB        |   347,703.1 ns |  1,295.96 ns |  1,148.84 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar           | 128B         |       365.4 ns |      2.01 ns |      1.88 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2             | 128B         |       434.4 ns |      1.34 ns |      1.12 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                      | 128B         |       488.2 ns |      0.59 ns |      0.49 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                         | 128B         |       510.8 ns |      2.21 ns |      1.96 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar           | 137B         |       806.0 ns |      5.85 ns |      5.18 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                      | 137B         |       859.2 ns |      4.16 ns |      3.89 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                         | 137B         |       874.6 ns |      5.00 ns |      4.43 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2             | 137B         |       950.2 ns |      4.04 ns |      3.78 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar           | 1KB          |     2,434.0 ns |     15.15 ns |     12.65 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2             | 1KB          |     3,043.2 ns |      9.46 ns |      7.38 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                         | 1KB          |     3,200.1 ns |     13.80 ns |     12.24 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                      | 1KB          |     3,221.8 ns |     11.24 ns |     10.51 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar           | 1025B        |     2,439.2 ns |      7.42 ns |      6.58 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2             | 1025B        |     3,048.9 ns |     13.29 ns |     11.10 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                         | 1025B        |     3,197.6 ns |     12.93 ns |     11.46 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                      | 1025B        |     3,222.7 ns |     23.74 ns |     21.04 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar           | 8KB          |    17,209.6 ns |     51.94 ns |     46.04 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2             | 8KB          |    22,308.5 ns |    118.98 ns |    105.47 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                         | 8KB          |    23,538.4 ns |    286.70 ns |    268.17 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                      | 8KB          |    23,542.1 ns |    162.23 ns |    143.81 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar           | 128KB        |   267,021.9 ns |    997.88 ns |    884.59 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2             | 128KB        |   350,339.0 ns |  1,521.86 ns |  1,349.09 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                         | 128KB        |   364,403.6 ns |  1,384.21 ns |  1,294.79 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                      | 128KB        |   368,764.5 ns |  1,382.06 ns |  1,292.78 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar           | 128B         |       723.7 ns |      2.68 ns |      2.50 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                      | 128B         |       865.2 ns |      2.40 ns |      1.87 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                         | 128B         |       875.9 ns |      6.00 ns |      5.01 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2             | 128B         |       883.8 ns |      7.44 ns |      6.59 ns |     144 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar           | 137B         |       722.7 ns |      2.47 ns |      2.19 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                      | 137B         |       857.6 ns |      2.21 ns |      1.84 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2             | 137B         |       864.3 ns |      3.35 ns |      3.13 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                         | 137B         |       875.0 ns |      2.61 ns |      2.44 ns |     144 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar           | 1KB          |     2,955.9 ns |     46.03 ns |     43.06 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2             | 1KB          |     3,711.8 ns |     35.55 ns |     31.51 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                         | 1KB          |     3,926.9 ns |     19.06 ns |     15.92 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                      | 1KB          |     3,952.3 ns |     22.36 ns |     19.82 ns |     144 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar           | 1025B        |     2,918.4 ns |     25.10 ns |     22.25 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2             | 1025B        |     3,692.2 ns |     16.63 ns |     15.55 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                         | 1025B        |     3,923.9 ns |     26.46 ns |     23.46 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                      | 1025B        |     3,970.3 ns |     29.46 ns |     27.55 ns |     144 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar           | 8KB          |    21,828.9 ns |     83.51 ns |     69.74 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2             | 8KB          |    28,783.4 ns |     97.58 ns |     86.51 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                         | 8KB          |    29,642.1 ns |    113.80 ns |     95.03 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                      | 8KB          |    30,051.2 ns |    155.35 ns |    137.72 ns |     144 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar           | 128KB        |   351,057.4 ns |  6,005.81 ns |  5,617.84 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2             | 128KB        |   455,727.2 ns |  1,931.00 ns |  1,612.47 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                         | 128KB        |   471,398.5 ns |  2,618.45 ns |  2,321.19 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                      | 128KB        |   488,951.5 ns |  4,188.95 ns |  3,713.40 ns |     144 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar           | 128B         |       658.8 ns |      8.62 ns |      8.07 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2             | 128B         |       801.1 ns |      5.24 ns |      4.90 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                      | 128B         |       856.0 ns |      3.64 ns |      3.41 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                         | 128B         |       878.8 ns |      3.90 ns |      3.46 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar           | 137B         |       639.7 ns |      3.28 ns |      2.74 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2             | 137B         |       787.1 ns |      2.88 ns |      2.69 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                      | 137B         |       863.5 ns |      2.49 ns |      2.21 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                         | 137B         |       882.9 ns |      4.22 ns |      3.74 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar           | 1KB          |     4,277.7 ns |     20.78 ns |     17.35 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2             | 1KB          |     5,486.2 ns |     17.24 ns |     14.40 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                         | 1KB          |     5,698.6 ns |     12.92 ns |     11.45 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                      | 1KB          |     5,749.0 ns |     26.68 ns |     23.65 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar           | 1025B        |     4,311.4 ns |     19.61 ns |     18.35 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2             | 1025B        |     5,499.1 ns |     13.81 ns |     11.53 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                         | 1025B        |     5,705.2 ns |     26.58 ns |     23.56 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                      | 1025B        |     5,767.9 ns |     28.63 ns |     25.38 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar           | 8KB          |    31,030.5 ns |     39.64 ns |     30.95 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2             | 8KB          |    41,241.8 ns |    180.12 ns |    168.48 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                         | 8KB          |    42,152.2 ns |    198.05 ns |    185.26 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                      | 8KB          |    43,289.0 ns |    297.41 ns |    263.64 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar           | 128KB        |   496,174.2 ns |  2,785.17 ns |  2,468.98 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2             | 128KB        |   650,997.7 ns |  2,179.29 ns |  1,701.45 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                         | 128KB        |   669,337.3 ns |  4,320.01 ns |  3,607.40 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                      | 128KB        |   681,680.1 ns |  6,927.91 ns |  6,141.41 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar           | 128B         |       446.0 ns |      8.20 ns |      6.84 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                      | 128B         |       494.6 ns |      4.45 ns |      3.71 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2             | 128B         |       502.5 ns |      2.01 ns |      1.78 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                         | 128B         |       620.0 ns |      3.10 ns |      2.90 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar           | 137B         |       437.3 ns |      4.04 ns |      3.78 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                      | 137B         |       496.8 ns |      7.89 ns |      7.38 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2             | 137B         |       500.5 ns |      2.27 ns |      2.02 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                         | 137B         |       624.9 ns |      3.18 ns |      2.82 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar           | 1KB          |     2,328.8 ns |     16.23 ns |     14.38 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                      | 1KB          |     2,861.7 ns |     21.70 ns |     19.24 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2             | 1KB          |     2,875.7 ns |     25.32 ns |     21.15 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                         | 1KB          |     2,946.5 ns |     38.76 ns |     36.25 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar           | 1025B        |     2,317.3 ns |     12.85 ns |     10.73 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                      | 1025B        |     2,856.9 ns |     16.41 ns |     13.71 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2             | 1025B        |     2,868.6 ns |     31.56 ns |     26.35 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                         | 1025B        |     2,928.0 ns |     21.86 ns |     18.25 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar           | 8KB          |    13,935.3 ns |     89.32 ns |     79.18 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2             | 8KB          |    18,047.4 ns |     97.61 ns |     81.51 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                         | 8KB          |    19,127.2 ns |    129.14 ns |    120.79 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                      | 8KB          |    19,134.8 ns |    120.87 ns |    100.93 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar           | 128KB        |   218,860.9 ns |  1,706.67 ns |  1,512.92 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2             | 128KB        |   286,904.3 ns |  1,926.92 ns |  1,708.16 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                         | 128KB        |   299,767.9 ns |  1,776.46 ns |  1,661.71 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                      | 128KB        |   301,447.2 ns |  2,445.56 ns |  2,167.93 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar           | 128B         |       449.7 ns |      8.79 ns |      9.03 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                      | 128B         |       495.9 ns |      4.94 ns |      4.62 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2             | 128B         |       505.1 ns |      3.78 ns |      3.15 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                         | 128B         |       633.3 ns |      5.53 ns |      4.90 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHAKE256 | BouncyCastle                      | 137B         |       872.1 ns |      3.47 ns |      3.08 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar           | 137B         |       882.4 ns |      3.18 ns |      2.66 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                         | 137B         |     1,004.5 ns |      9.04 ns |      8.46 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2             | 137B         |     1,032.6 ns |      5.92 ns |      5.25 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar           | 1KB          |     2,515.3 ns |     21.85 ns |     19.37 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2             | 1KB          |     3,128.8 ns |     15.90 ns |     14.10 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                      | 1KB          |     3,234.3 ns |     24.66 ns |     20.59 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                         | 1KB          |     3,270.4 ns |     12.09 ns |      9.44 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar           | 1025B        |     2,498.2 ns |     14.21 ns |     11.86 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2             | 1025B        |     3,131.8 ns |     19.37 ns |     16.18 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                      | 1025B        |     3,224.1 ns |     16.60 ns |     14.72 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                         | 1025B        |     3,271.7 ns |     12.34 ns |     10.31 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar           | 8KB          |    17,513.0 ns |    250.99 ns |    234.77 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2             | 8KB          |    22,375.5 ns |    142.27 ns |    118.80 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                      | 8KB          |    23,563.0 ns |    170.14 ns |    150.82 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                         | 8KB          |    23,670.2 ns |    410.62 ns |    439.36 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar           | 128KB        |   268,175.6 ns |  2,262.60 ns |  2,116.43 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2             | 128KB        |   351,485.4 ns |  1,618.81 ns |  1,351.78 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                         | 128KB        |   365,637.2 ns |  2,473.06 ns |  2,192.31 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                      | 128KB        |   367,672.1 ns |  3,356.76 ns |  2,803.05 ns |     176 B |
|                                                            |              |                |              |              |           |
| **ComputeHash | SM3 | CryptoHives**                            | **128B**         |     **1,005.5 ns** |      **8.61 ns** |      **7.19 ns** |     **112 B** |
| **ComputeHash | SM3 | BouncyCastle**                           | **128B**         |     **1,005.9 ns** |      **9.19 ns** |      **8.59 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| ComputeHash | SM3 | BouncyCastle                           | 137B         |       997.3 ns |     11.67 ns |     10.35 ns |     112 B |
| **ComputeHash | SM3 | CryptoHives**                            | **137B**         |     **1,021.5 ns** |      **3.46 ns** |      **2.70 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SM3 | BouncyCastle**                           | **1KB**          |     **5,153.6 ns** |     **26.15 ns** |     **21.83 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                            | **1KB**          |     **5,371.3 ns** |     **44.25 ns** |     **39.23 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SM3 | BouncyCastle**                           | **1025B**        |     **5,252.4 ns** |     **75.50 ns** |     **70.62 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                            | **1025B**        |     **5,418.3 ns** |     **78.37 ns** |     **73.31 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SM3 | BouncyCastle**                           | **8KB**          |    **38,450.6 ns** |    **176.30 ns** |    **147.22 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                            | **8KB**          |    **40,171.4 ns** |    **301.25 ns** |    **267.05 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | SM3 | BouncyCastle**                           | **128KB**        |   **611,501.7 ns** |  **3,147.00 ns** |  **2,789.73 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                            | **128KB**        |   **635,424.9 ns** |  **2,827.09 ns** |  **2,360.75 ns** |     **112 B** |
|                                                            |              |                |              |              |           |
| ComputeHash | Streebog-256 | CryptoHives                   | 128B         |     2,625.1 ns |     19.66 ns |     17.43 ns |     112 B |
| **ComputeHash | Streebog-256 | OpenGost**                      | **128B**         |     **4,644.7 ns** |     **22.39 ns** |     **17.48 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                  | 128B         |     6,495.9 ns |     96.17 ns |     89.96 ns |     200 B |
|                                                            |              |                |              |              |           |
| **ComputeHash | Streebog-256 | CryptoHives**                   | **137B**         |     **2,616.9 ns** |     **14.29 ns** |     **11.93 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                      | **137B**         |     **4,635.4 ns** |     **17.39 ns** |     **13.58 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                  | 137B         |     6,468.8 ns |     38.39 ns |     32.06 ns |     200 B |
|                                                            |              |                |              |              |           |
| **ComputeHash | Streebog-256 | CryptoHives**                   | **1KB**          |     **9,695.7 ns** |     **50.88 ns** |     **45.11 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                      | **1KB**          |    **17,086.4 ns** |    **132.31 ns** |    **117.29 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                  | 1KB          |    24,493.6 ns |    189.88 ns |    177.61 ns |     200 B |
|                                                            |              |                |              |              |           |
| **ComputeHash | Streebog-256 | CryptoHives**                   | **1025B**        |     **9,855.7 ns** |     **91.90 ns** |     **85.96 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                      | **1025B**        |    **17,024.8 ns** |    **105.53 ns** |     **88.12 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                  | 1025B        |    24,254.5 ns |     93.13 ns |     72.71 ns |     200 B |
|                                                            |              |                |              |              |           |
| **ComputeHash | Streebog-256 | CryptoHives**                   | **8KB**          |    **67,697.3 ns** |    **360.40 ns** |    **337.12 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                      | **8KB**          |   **116,114.6 ns** |    **531.02 ns** |    **414.59 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                  | 8KB          |   168,379.8 ns |  2,288.45 ns |  2,140.61 ns |     200 B |
|                                                            |              |                |              |              |           |
| **ComputeHash | Streebog-256 | CryptoHives**                   | **128KB**        | **1,082,557.1 ns** |  **7,667.49 ns** |  **6,402.70 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                      | **128KB**        | **1,836,870.9 ns** | **33,224.99 ns** | **34,119.62 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                  | 128KB        | 2,628,703.0 ns | 19,454.45 ns | 17,245.86 ns |     200 B |
|                                                            |              |                |              |              |           |
| **ComputeHash | Streebog-512 | CryptoHives**                   | **128B**         |     **2,672.1 ns** |     **15.49 ns** |     **13.73 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                      | **128B**         |     **4,504.7 ns** |     **12.24 ns** |     **10.22 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                  | 128B         |     6,498.4 ns |     39.04 ns |     34.61 ns |     176 B |
|                                                            |              |                |              |              |           |
| **ComputeHash | Streebog-512 | CryptoHives**                   | **137B**         |     **2,647.2 ns** |     **24.35 ns** |     **21.58 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                      | **137B**         |     **4,511.4 ns** |     **31.96 ns** |     **28.33 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                  | 137B         |     6,429.8 ns |     20.32 ns |     16.97 ns |     176 B |
|                                                            |              |                |              |              |           |
| **ComputeHash | Streebog-512 | CryptoHives**                   | **1KB**          |     **9,817.7 ns** |     **92.11 ns** |     **81.65 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                      | **1KB**          |    **17,107.7 ns** |    **247.66 ns** |    **231.66 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                  | 1KB          |    24,568.1 ns |    229.86 ns |    203.77 ns |     176 B |
|                                                            |              |                |              |              |           |
| **ComputeHash | Streebog-512 | CryptoHives**                   | **1025B**        |    **10,032.5 ns** |     **62.48 ns** |     **52.17 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                      | **1025B**        |    **16,946.1 ns** |    **154.35 ns** |    **136.83 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                  | 1025B        |    26,296.5 ns |    182.24 ns |    161.55 ns |     176 B |
|                                                            |              |                |              |              |           |
| **ComputeHash | Streebog-512 | CryptoHives**                   | **8KB**          |    **68,841.3 ns** |    **466.40 ns** |    **389.47 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                      | **8KB**          |   **115,894.8 ns** |    **908.93 ns** |    **805.74 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                  | 8KB          |   167,199.6 ns |    966.79 ns |    807.31 ns |     176 B |
|                                                            |              |                |              |              |           |
| **ComputeHash | Streebog-512 | CryptoHives**                   | **128KB**        | **1,099,130.4 ns** |  **7,620.72 ns** |  **6,755.57 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                      | **128KB**        | **1,818,199.1 ns** | **15,813.92 ns** | **14,018.63 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                  | 128KB        | 2,614,280.1 ns | 12,199.23 ns | 10,186.91 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar | 128B         |       305.4 ns |      1.90 ns |      1.59 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2   | 128B         |       333.6 ns |      2.42 ns |      2.14 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar | 137B         |       299.9 ns |      1.55 ns |      1.29 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2   | 137B         |       324.2 ns |      1.46 ns |      1.14 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar | 1KB          |     1,425.2 ns |     13.45 ns |     12.59 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2   | 1KB          |     1,650.1 ns |     15.24 ns |     14.26 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar | 1025B        |     1,435.4 ns |     23.10 ns |     21.61 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2   | 1025B        |     1,648.7 ns |     22.23 ns |     20.79 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar | 8KB          |     7,635.0 ns |     61.64 ns |     57.66 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2   | 8KB          |     9,724.6 ns |     71.64 ns |     59.82 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar | 128KB        |   118,991.8 ns |  1,722.22 ns |  1,438.13 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2   | 128KB        |   152,120.5 ns |  1,331.49 ns |  1,180.33 ns |     112 B |
|                                                            |              |                |              |              |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar | 128B         |       311.0 ns |      2.35 ns |      2.09 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2   | 128B         |       335.8 ns |      1.54 ns |      1.28 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar | 137B         |       634.2 ns |     11.28 ns |     10.55 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2   | 137B         |       691.4 ns |      5.78 ns |      5.12 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar | 1KB          |     1,505.4 ns |      5.25 ns |      4.66 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2   | 1KB          |     1,750.3 ns |     12.44 ns |     11.03 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar | 1025B        |     1,506.6 ns |     13.82 ns |     12.25 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2   | 1025B        |     1,742.4 ns |     11.32 ns |      9.45 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar | 8KB          |     9,407.0 ns |     97.67 ns |     86.58 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2   | 8KB          |    11,962.3 ns |     63.24 ns |     52.81 ns |     176 B |
|                                                            |              |                |              |              |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar | 128KB        |   143,289.6 ns |  1,245.01 ns |  1,039.64 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2   | 128KB        |   185,188.7 ns |  1,249.09 ns |  1,107.29 ns |     176 B |
|                                                            |              |                |              |              |           |
| **ComputeHash | Whirlpool | CryptoHives**                      | **128B**         |     **1,939.0 ns** |     **14.81 ns** |     **12.36 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                     | **128B**         |     **7,814.2 ns** |     **43.46 ns** |     **38.53 ns** |     **232 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | Whirlpool | CryptoHives**                      | **137B**         |     **1,940.6 ns** |     **13.92 ns** |     **11.63 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                     | **137B**         |     **7,870.0 ns** |    **103.08 ns** |     **91.38 ns** |     **232 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | Whirlpool | CryptoHives**                      | **1KB**          |    **10,490.1 ns** |     **55.38 ns** |     **46.24 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                     | **1KB**          |    **47,602.6 ns** |    **583.40 ns** |    **517.17 ns** |     **232 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | Whirlpool | CryptoHives**                      | **1025B**        |    **10,523.0 ns** |     **81.17 ns** |     **71.95 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                     | **1025B**        |    **47,403.9 ns** |    **248.65 ns** |    **207.64 ns** |     **232 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | Whirlpool | CryptoHives**                      | **8KB**          |    **79,309.6 ns** |    **669.71 ns** |    **593.68 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                     | **8KB**          |   **364,194.7 ns** |  **2,368.46 ns** |  **2,099.58 ns** |     **232 B** |
|                                                            |              |                |              |              |           |
| **ComputeHash | Whirlpool | CryptoHives**                      | **128KB**        | **1,255,148.0 ns** |  **9,075.52 ns** |  **8,045.22 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                     | **128KB**        | **5,780,221.3 ns** | **48,839.31 ns** | **43,294.78 ns** |     **232 B** |
