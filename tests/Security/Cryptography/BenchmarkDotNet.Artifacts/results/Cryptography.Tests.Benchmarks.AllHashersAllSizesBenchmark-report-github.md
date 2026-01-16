```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7623/25H2/2025Update/HudsonValley2)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.101
  [Host]    : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                          | TestDataSize | Mean           | Error        | StdDev       | Median         | Allocated |
|----------------------------------------------------- |------------- |---------------:|-------------:|-------------:|---------------:|----------:|
| **ComputeHash | BLAKE2b-512 | BouncyCastle**             | **128B**         |       **141.7 ns** |      **0.73 ns** |      **0.69 ns** |       **141.6 ns** |     **176 B** |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2     | 128B         |       169.2 ns |      1.59 ns |      1.49 ns |       169.5 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar   | 128B         |       436.1 ns |      2.65 ns |      2.48 ns |       436.6 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle             | 137B         |       226.2 ns |      1.17 ns |      1.09 ns |       226.6 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2     | 137B         |       265.7 ns |      1.68 ns |      1.57 ns |       265.1 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar   | 137B         |       821.6 ns |      4.10 ns |      3.83 ns |       822.1 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle             | 1KB          |       762.3 ns |      2.20 ns |      2.05 ns |       762.5 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2     | 1KB          |       924.5 ns |      3.77 ns |      3.34 ns |       924.5 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar   | 1KB          |     3,098.6 ns |     16.22 ns |     15.17 ns |     3,097.7 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle             | 1025B        |       849.4 ns |      2.95 ns |      2.62 ns |       848.9 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2     | 1025B        |     1,046.9 ns |      3.51 ns |      3.29 ns |     1,045.4 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar   | 1025B        |     3,516.0 ns |     14.41 ns |     12.77 ns |     3,521.0 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle             | 8KB          |     5,690.8 ns |      9.28 ns |      8.23 ns |     5,691.1 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2     | 8KB          |     7,156.4 ns |     35.36 ns |     31.34 ns |     7,149.1 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar   | 8KB          |    24,378.8 ns |     98.43 ns |     82.19 ns |    24,378.9 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle             | 128KB        |    90,287.7 ns |    323.13 ns |    286.44 ns |    90,248.4 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2     | 128KB        |   114,046.3 ns |    524.42 ns |    490.55 ns |   113,916.9 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar   | 128KB        |   392,263.8 ns |  2,614.87 ns |  2,445.95 ns |   391,466.8 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle             | 128B         |       204.4 ns |      0.88 ns |      0.73 ns |       204.5 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2     | 128B         |       206.4 ns |      1.01 ns |      0.95 ns |       206.4 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2     | 128B         |       227.9 ns |      1.23 ns |      1.03 ns |       227.8 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar   | 128B         |       675.2 ns |      3.86 ns |      3.42 ns |       674.5 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle             | 137B         |       280.0 ns |      1.23 ns |      1.15 ns |       279.9 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2     | 137B         |       291.6 ns |      1.73 ns |      1.53 ns |       291.3 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2     | 137B         |       327.9 ns |      2.23 ns |      2.08 ns |       327.5 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar   | 137B         |       990.0 ns |      6.37 ns |      5.64 ns |       989.3 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle             | 1KB          |     1,275.7 ns |      3.66 ns |      3.24 ns |     1,276.4 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2     | 1KB          |     1,347.9 ns |      8.76 ns |      7.32 ns |     1,347.1 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2     | 1KB          |     1,545.8 ns |     22.34 ns |     21.94 ns |     1,540.0 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar   | 1KB          |     5,085.4 ns |     40.82 ns |     38.18 ns |     5,090.7 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle             | 1025B        |     1,347.3 ns |      1.92 ns |      1.79 ns |     1,347.7 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2     | 1025B        |     1,420.4 ns |      2.04 ns |      1.70 ns |     1,419.9 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2     | 1025B        |     1,633.2 ns |      9.66 ns |      9.03 ns |     1,629.4 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar   | 1025B        |     5,359.8 ns |     21.69 ns |     20.29 ns |     5,361.3 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle             | 8KB          |     9,822.2 ns |     46.20 ns |     43.22 ns |     9,841.9 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2     | 8KB          |    10,423.1 ns |     85.65 ns |     75.92 ns |    10,421.9 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2     | 8KB          |    11,901.3 ns |     41.30 ns |     38.63 ns |    11,888.2 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar   | 8KB          |    40,188.1 ns |    244.01 ns |    228.24 ns |    40,210.6 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle             | 128KB        |   156,044.2 ns |    356.37 ns |    333.35 ns |   156,195.8 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2     | 128KB        |   166,591.3 ns |    832.12 ns |    737.65 ns |   166,708.6 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2     | 128KB        |   189,789.8 ns |    708.65 ns |    662.87 ns |   189,424.3 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar   | 128KB        |   645,785.2 ns |  9,422.60 ns |  9,676.31 ns |   641,084.6 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE3 | Native                        | 128B         |       124.4 ns |      0.29 ns |      0.27 ns |       124.3 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3          | 128B         |       413.5 ns |      1.25 ns |      1.11 ns |       413.5 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar         | 128B         |       626.4 ns |      4.62 ns |      3.86 ns |       625.8 ns |     112 B |
| ComputeHash | BLAKE3 | BouncyCastle                  | 128B         |     1,379.7 ns |      5.71 ns |      5.07 ns |     1,378.9 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE3 | Native                        | 137B         |       172.4 ns |      0.31 ns |      0.27 ns |       172.4 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3          | 137B         |       485.5 ns |      3.75 ns |      3.51 ns |       484.2 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar         | 137B         |       898.1 ns |      6.34 ns |      5.93 ns |       898.4 ns |     112 B |
| ComputeHash | BLAKE3 | BouncyCastle                  | 137B         |     2,013.5 ns |     11.56 ns |     10.81 ns |     2,013.3 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE3 | Native                        | 1KB          |       773.4 ns |      0.99 ns |      0.83 ns |       773.3 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3          | 1KB          |     1,393.6 ns |      6.00 ns |      5.61 ns |     1,391.6 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar         | 1KB          |     4,538.9 ns |     23.57 ns |     22.05 ns |     4,547.3 ns |     112 B |
| ComputeHash | BLAKE3 | BouncyCastle                  | 1KB          |    10,149.5 ns |     36.04 ns |     33.71 ns |    10,155.8 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE3 | Native                        | 1025B        |       876.1 ns |      1.21 ns |      1.13 ns |       875.9 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3          | 1025B        |     1,555.6 ns |      4.31 ns |      4.03 ns |     1,554.8 ns |     224 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar         | 1025B        |     5,136.2 ns |     15.57 ns |     13.00 ns |     5,139.8 ns |     224 B |
| ComputeHash | BLAKE3 | BouncyCastle                  | 1025B        |    11,413.2 ns |     26.76 ns |     23.72 ns |    11,408.2 ns |     168 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE3 | Native                        | 8KB          |     1,214.2 ns |      6.18 ns |      5.78 ns |     1,214.2 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3          | 8KB          |    11,108.3 ns |     25.89 ns |     22.95 ns |    11,100.1 ns |     896 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar         | 8KB          |    38,321.1 ns |    107.15 ns |     94.98 ns |    38,335.4 ns |     896 B |
| ComputeHash | BLAKE3 | BouncyCastle                  | 8KB          |    86,330.6 ns |    318.67 ns |    266.10 ns |    86,308.5 ns |     504 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | BLAKE3 | Native                        | 128KB        |    14,899.7 ns |     63.50 ns |     59.40 ns |    14,895.2 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3          | 128KB        |   181,894.9 ns |  1,034.68 ns |    807.81 ns |   182,069.1 ns |   14336 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar         | 128KB        |   628,603.4 ns |  2,986.51 ns |  2,493.87 ns |   628,302.7 ns |   14336 B |
| ComputeHash | BLAKE3 | BouncyCastle                  | 128KB        | 1,374,060.7 ns |  7,237.32 ns |  6,769.79 ns | 1,374,386.7 ns |    7224 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | CSHAKE128 | CryptoHives**                | **128B**         |       **308.2 ns** |      **1.95 ns** |      **1.82 ns** |       **307.8 ns** |     **112 B** |
| **ComputeHash | CSHAKE128 | BouncyCastle**               | **128B**         |       **391.6 ns** |      **1.86 ns** |      **1.65 ns** |       **391.3 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | CSHAKE128 | CryptoHives**                | **137B**         |       **300.5 ns** |      **2.74 ns** |      **2.56 ns** |       **299.5 ns** |     **112 B** |
| **ComputeHash | CSHAKE128 | BouncyCastle**               | **137B**         |       **393.2 ns** |      **1.37 ns** |      **1.28 ns** |       **392.6 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | CSHAKE128 | CryptoHives**                | **1KB**          |     **1,651.3 ns** |      **3.89 ns** |      **3.25 ns** |     **1,650.3 ns** |     **112 B** |
| **ComputeHash | CSHAKE128 | BouncyCastle**               | **1KB**          |     **2,374.4 ns** |     **13.49 ns** |     **11.96 ns** |     **2,370.5 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | CSHAKE128 | CryptoHives**                | **1025B**        |     **1,634.6 ns** |     **12.34 ns** |     **11.54 ns** |     **1,632.5 ns** |     **112 B** |
| **ComputeHash | CSHAKE128 | BouncyCastle**               | **1025B**        |     **2,367.6 ns** |     **12.72 ns** |     **11.90 ns** |     **2,365.6 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | CSHAKE128 | CryptoHives**                | **8KB**          |    **10,645.1 ns** |     **49.36 ns** |     **41.22 ns** |    **10,628.7 ns** |     **112 B** |
| **ComputeHash | CSHAKE128 | BouncyCastle**               | **8KB**          |    **16,208.4 ns** |     **58.35 ns** |     **48.73 ns** |    **16,220.9 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | CSHAKE128 | CryptoHives**                | **128KB**        |   **169,629.4 ns** |  **1,476.12 ns** |  **1,380.76 ns** |   **169,095.0 ns** |     **112 B** |
| **ComputeHash | CSHAKE128 | BouncyCastle**               | **128KB**        |   **260,360.3 ns** |  **2,595.73 ns** |  **2,428.04 ns** |   **259,356.1 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | CSHAKE256 | CryptoHives**                | **128B**         |       **302.2 ns** |      **1.36 ns** |      **1.14 ns** |       **302.3 ns** |     **176 B** |
| **ComputeHash | CSHAKE256 | BouncyCastle**               | **128B**         |       **390.6 ns** |      **0.68 ns** |      **0.57 ns** |       **390.5 ns** |     **176 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | CSHAKE256 | CryptoHives**                | **137B**         |       **572.4 ns** |      **5.64 ns** |      **5.27 ns** |       **572.2 ns** |     **176 B** |
| **ComputeHash | CSHAKE256 | BouncyCastle**               | **137B**         |       **714.0 ns** |      **2.07 ns** |      **1.83 ns** |       **713.6 ns** |     **176 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | CSHAKE256 | CryptoHives**                | **1KB**          |     **1,807.6 ns** |     **18.57 ns** |     **17.37 ns** |     **1,803.8 ns** |     **176 B** |
| **ComputeHash | CSHAKE256 | BouncyCastle**               | **1KB**          |     **2,801.2 ns** |     **11.93 ns** |     **10.58 ns** |     **2,798.9 ns** |     **176 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | CSHAKE256 | CryptoHives**                | **1025B**        |     **1,803.0 ns** |      **9.38 ns** |      **8.77 ns** |     **1,803.2 ns** |     **176 B** |
| **ComputeHash | CSHAKE256 | BouncyCastle**               | **1025B**        |     **2,683.9 ns** |      **6.16 ns** |      **4.81 ns** |     **2,682.6 ns** |     **176 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | CSHAKE256 | CryptoHives**                | **8KB**          |    **13,091.8 ns** |     **48.08 ns** |     **40.15 ns** |    **13,083.2 ns** |     **176 B** |
| **ComputeHash | CSHAKE256 | BouncyCastle**               | **8KB**          |    **20,108.4 ns** |     **81.28 ns** |     **67.87 ns** |    **20,096.8 ns** |     **176 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | CSHAKE256 | CryptoHives**                | **128KB**        |   **206,828.5 ns** |    **962.91 ns** |    **853.59 ns** |   **206,904.9 ns** |     **176 B** |
| **ComputeHash | CSHAKE256 | BouncyCastle**               | **128KB**        |   **315,067.4 ns** |  **1,945.83 ns** |  **1,624.86 ns** |   **315,412.9 ns** |     **176 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar  | 128B         |       262.1 ns |      1.75 ns |      1.37 ns |       262.6 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F | 128B         |       325.1 ns |      0.81 ns |      0.72 ns |       325.0 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle              | 128B         |       390.8 ns |      1.89 ns |      1.58 ns |       391.3 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar  | 137B         |       548.2 ns |      1.85 ns |      1.73 ns |       548.3 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F | 137B         |       641.8 ns |      2.00 ns |      1.56 ns |       642.0 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle              | 137B         |       706.3 ns |      7.54 ns |      6.68 ns |       704.2 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar  | 1KB          |     1,772.3 ns |     10.69 ns |     10.00 ns |     1,766.3 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F | 1KB          |     2,254.6 ns |      8.58 ns |      8.02 ns |     2,255.3 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle              | 1KB          |     2,691.3 ns |     23.29 ns |     21.79 ns |     2,690.8 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar  | 1025B        |     1,766.9 ns |     15.64 ns |     14.63 ns |     1,763.7 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F | 1025B        |     2,251.0 ns |      6.87 ns |      6.43 ns |     2,250.2 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle              | 1025B        |     2,682.9 ns |     15.49 ns |     14.49 ns |     2,676.6 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar  | 8KB          |    13,024.0 ns |     72.88 ns |     60.86 ns |    13,001.7 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F | 8KB          |    16,750.6 ns |     46.00 ns |     43.03 ns |    16,758.1 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle              | 8KB          |    20,047.9 ns |     70.74 ns |     62.71 ns |    20,039.9 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar  | 128KB        |   205,603.3 ns |  1,162.75 ns |  1,030.75 ns |   205,405.8 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F | 128KB        |   263,505.6 ns |    794.66 ns |    704.45 ns |   263,734.1 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle              | 128KB        |   317,591.8 ns |  2,420.78 ns |  2,264.40 ns |   317,241.7 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                 | **128B**         |       **789.7 ns** |      **3.27 ns** |      **2.73 ns** |       **789.3 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                   | **128B**         |     **1,149.2 ns** |     **14.50 ns** |     **13.56 ns** |     **1,147.5 ns** |     **296 B** |
| ComputeHash | KMAC-128 | BouncyCastle                | 128B         |     2,161.0 ns |      7.47 ns |      6.23 ns |     2,161.7 ns |     400 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                 | **137B**         |       **790.2 ns** |      **6.64 ns** |      **5.54 ns** |       **788.9 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                   | **137B**         |     **1,160.8 ns** |      **6.09 ns** |      **5.40 ns** |     **1,159.1 ns** |     **312 B** |
| ComputeHash | KMAC-128 | BouncyCastle                | 137B         |     2,182.7 ns |     11.44 ns |     10.70 ns |     2,180.8 ns |     400 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                 | **1KB**          |     **2,214.7 ns** |     **19.44 ns** |     **18.18 ns** |     **2,208.4 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                   | **1KB**          |     **2,750.7 ns** |     **25.30 ns** |     **22.43 ns** |     **2,741.1 ns** |    **1192 B** |
| ComputeHash | KMAC-128 | BouncyCastle                | 1KB          |     4,151.3 ns |     18.26 ns |     15.25 ns |     4,153.2 ns |     400 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                 | **1025B**        |     **2,204.6 ns** |      **8.28 ns** |      **6.46 ns** |     **2,206.0 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                   | **1025B**        |     **2,769.7 ns** |     **19.77 ns** |     **18.49 ns** |     **2,764.2 ns** |    **1200 B** |
| ComputeHash | KMAC-128 | BouncyCastle                | 1025B        |     4,161.7 ns |     21.48 ns |     20.09 ns |     4,157.9 ns |     400 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                 | **8KB**          |    **11,226.9 ns** |     **64.07 ns** |     **56.80 ns** |    **11,206.7 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                   | **8KB**          |    **14,149.5 ns** |    **121.13 ns** |    **113.30 ns** |    **14,109.5 ns** |    **8360 B** |
| ComputeHash | KMAC-128 | BouncyCastle                | 8KB          |    18,079.1 ns |     82.15 ns |     72.82 ns |    18,067.9 ns |     400 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                 | **128KB**        |   **170,487.7 ns** |  **1,947.31 ns** |  **1,726.24 ns** |   **170,648.2 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                   | **128KB**        |   **235,429.3 ns** |  **1,043.93 ns** |    **925.42 ns** |   **235,517.0 ns** |  **131263 B** |
| ComputeHash | KMAC-128 | BouncyCastle                | 128KB        |   259,919.4 ns |  1,091.78 ns |    911.69 ns |   259,681.2 ns |     400 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                 | **128B**         |       **792.5 ns** |      **3.34 ns** |      **2.96 ns** |       **792.2 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                   | **128B**         |     **1,172.3 ns** |      **8.45 ns** |      **7.91 ns** |     **1,169.9 ns** |     **360 B** |
| ComputeHash | KMAC-256 | BouncyCastle                | 128B         |     2,201.0 ns |      9.68 ns |      8.58 ns |     2,200.3 ns |     464 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                 | **137B**         |     **1,055.2 ns** |      **6.90 ns** |      **6.12 ns** |     **1,053.8 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                   | **137B**         |     **1,416.9 ns** |      **6.39 ns** |      **5.66 ns** |     **1,415.9 ns** |     **376 B** |
| ComputeHash | KMAC-256 | BouncyCastle                | 137B         |     2,465.5 ns |     21.52 ns |     20.13 ns |     2,463.9 ns |     464 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                 | **1KB**          |     **2,346.2 ns** |     **11.56 ns** |     **10.81 ns** |     **2,344.9 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                   | **1KB**          |     **3,010.0 ns** |     **17.59 ns** |     **16.46 ns** |     **3,005.2 ns** |    **1256 B** |
| ComputeHash | KMAC-256 | BouncyCastle                | 1KB          |     4,436.0 ns |     29.87 ns |     24.94 ns |     4,428.4 ns |     464 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                 | **1025B**        |     **2,350.1 ns** |     **10.17 ns** |      **7.94 ns** |     **2,350.6 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                   | **1025B**        |     **3,002.4 ns** |      **9.36 ns** |      **7.81 ns** |     **3,002.6 ns** |    **1264 B** |
| ComputeHash | KMAC-256 | BouncyCastle                | 1025B        |     4,447.5 ns |     40.32 ns |     37.72 ns |     4,430.2 ns |     464 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                 | **8KB**          |    **13,607.5 ns** |     **33.87 ns** |     **28.29 ns** |    **13,612.2 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                   | **8KB**          |    **17,061.8 ns** |    **143.19 ns** |    **126.94 ns** |    **17,008.8 ns** |    **8424 B** |
| ComputeHash | KMAC-256 | BouncyCastle                | 8KB          |    21,786.8 ns |     82.43 ns |     68.83 ns |    21,763.9 ns |     464 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                 | **128KB**        |   **207,094.3 ns** |  **1,138.10 ns** |  **1,064.58 ns** |   **206,902.2 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                   | **128KB**        |   **281,206.2 ns** |  **2,440.95 ns** |  **2,283.26 ns** |   **280,350.5 ns** |  **131327 B** |
| ComputeHash | KMAC-256 | BouncyCastle                | 128KB        |   316,231.4 ns |  1,090.77 ns |    910.84 ns |   316,382.8 ns |     464 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | KT128 | CryptoHives**                    | **128B**         |       **253.4 ns** |      **2.42 ns** |      **2.02 ns** |       **253.1 ns** |     **584 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | KT128 | CryptoHives                    | 137B         |       254.1 ns |      2.64 ns |      2.34 ns |       254.6 ns |     584 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | KT128 | CryptoHives                    | 1KB          |     1,024.2 ns |      5.09 ns |      4.51 ns |     1,022.8 ns |     584 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | KT128 | CryptoHives                    | 1025B        |     1,018.3 ns |      3.79 ns |      3.36 ns |     1,017.7 ns |     584 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | KT128 | CryptoHives                    | 8KB          |     6,698.6 ns |     55.25 ns |     46.14 ns |     6,701.5 ns |    9328 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | KT128 | CryptoHives                    | 128KB        |    97,954.3 ns |    416.66 ns |    389.75 ns |    97,852.3 ns |   16888 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | KT256 | CryptoHives                    | 128B         |       250.6 ns |      1.77 ns |      1.48 ns |       250.9 ns |     616 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | KT256 | CryptoHives                    | 137B         |       426.4 ns |      2.40 ns |      2.00 ns |       426.1 ns |     616 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | KT256 | CryptoHives                    | 1KB          |     1,109.5 ns |     11.76 ns |      9.82 ns |     1,110.1 ns |     616 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | KT256 | CryptoHives                    | 1025B        |     1,106.3 ns |      7.60 ns |      6.34 ns |     1,105.9 ns |     616 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | KT256 | CryptoHives                    | 8KB          |     7,885.0 ns |     51.03 ns |     45.24 ns |     7,880.6 ns |    9360 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | KT256 | CryptoHives                    | 128KB        |   119,060.1 ns |    795.29 ns |    705.00 ns |   118,930.8 ns |   16920 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | MD5 | OS Native**                        | **128B**         |       **314.0 ns** |      **1.58 ns** |      **1.48 ns** |       **313.9 ns** |      **80 B** |
| **ComputeHash | MD5 | CryptoHives**                      | **128B**         |       **386.5 ns** |      **2.15 ns** |      **1.79 ns** |       **386.0 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                     | **128B**         |       **420.0 ns** |      **1.91 ns** |      **1.78 ns** |       **419.1 ns** |      **80 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | MD5 | OS Native                        | 137B         |       312.8 ns |      1.41 ns |      1.32 ns |       312.4 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                      | **137B**         |       **388.5 ns** |      **1.98 ns** |      **1.75 ns** |       **388.4 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                     | **137B**         |       **418.1 ns** |      **1.28 ns** |      **1.13 ns** |       **418.2 ns** |      **80 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | MD5 | OS Native                        | 1KB          |     1,479.5 ns |      2.31 ns |      2.17 ns |     1,479.1 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                      | **1KB**          |     **1,969.9 ns** |     **12.17 ns** |     **10.79 ns** |     **1,966.5 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                     | **1KB**          |     **2,157.9 ns** |      **8.79 ns** |      **7.79 ns** |     **2,157.4 ns** |      **80 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | MD5 | OS Native                        | 1025B        |     1,481.1 ns |      2.13 ns |      1.99 ns |     1,481.6 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                      | **1025B**        |     **1,969.5 ns** |     **15.46 ns** |     **12.91 ns** |     **1,966.7 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                     | **1025B**        |     **2,158.3 ns** |      **9.05 ns** |      **8.46 ns** |     **2,155.3 ns** |      **80 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | MD5 | OS Native                        | 8KB          |    10,790.5 ns |     27.06 ns |     23.99 ns |    10,797.6 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                      | **8KB**          |    **14,575.0 ns** |     **71.46 ns** |     **66.84 ns** |    **14,590.5 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                     | **8KB**          |    **15,979.8 ns** |     **46.65 ns** |     **41.35 ns** |    **15,981.2 ns** |      **80 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | MD5 | OS Native                        | 128KB        |   170,432.7 ns |    525.70 ns |    466.02 ns |   170,415.1 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                      | **128KB**        |   **230,686.1 ns** |  **1,827.85 ns** |  **1,709.77 ns** |   **230,905.3 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                     | **128KB**        |   **253,933.8 ns** |  **1,160.50 ns** |  **1,085.53 ns** |   **254,100.5 ns** |      **80 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | RIPEMD-160 | BouncyCastle              | 128B         |       718.6 ns |      2.17 ns |      1.92 ns |       718.8 ns |      96 B |
| **ComputeHash | RIPEMD-160 | CryptoHives**               | **128B**         |     **1,074.2 ns** |     **15.44 ns** |     **14.44 ns** |     **1,076.8 ns** |      **96 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**              | **137B**         |       **731.2 ns** |     **14.14 ns** |     **33.05 ns** |       **717.8 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**               | **137B**         |     **1,069.0 ns** |     **20.37 ns** |     **17.01 ns** |     **1,064.1 ns** |      **96 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**              | **1KB**          |     **3,851.1 ns** |     **18.66 ns** |     **17.45 ns** |     **3,853.0 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**               | **1KB**          |     **5,829.0 ns** |     **57.78 ns** |     **48.25 ns** |     **5,826.4 ns** |      **96 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**              | **1025B**        |     **3,763.4 ns** |     **19.31 ns** |     **15.07 ns** |     **3,761.1 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**               | **1025B**        |     **5,850.5 ns** |     **95.61 ns** |    **102.31 ns** |     **5,809.2 ns** |      **96 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**              | **8KB**          |    **28,338.1 ns** |    **144.60 ns** |    **135.26 ns** |    **28,285.8 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**               | **8KB**          |    **44,907.7 ns** |    **873.16 ns** |    **816.76 ns** |    **44,706.2 ns** |      **96 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**              | **128KB**        |   **452,173.0 ns** |  **1,043.16 ns** |    **924.74 ns** |   **452,159.0 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**               | **128KB**        |   **711,761.0 ns** |  **4,851.70 ns** |  **4,051.39 ns** |   **712,728.9 ns** |      **96 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-1 | OS Native**                      | **128B**         |       **289.8 ns** |      **2.42 ns** |      **2.14 ns** |       **290.3 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                   | 128B         |       499.8 ns |      2.38 ns |      2.11 ns |       499.5 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                    | **128B**         |       **524.3 ns** |      **3.00 ns** |      **2.66 ns** |       **524.4 ns** |      **96 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-1 | OS Native**                      | **137B**         |       **282.5 ns** |      **1.28 ns** |      **1.20 ns** |       **282.7 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                   | 137B         |       506.8 ns |      5.59 ns |      5.23 ns |       505.1 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                    | **137B**         |       **525.8 ns** |      **5.32 ns** |      **4.72 ns** |       **526.1 ns** |      **96 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-1 | OS Native**                      | **1KB**          |     **1,214.5 ns** |      **7.71 ns** |      **6.83 ns** |     **1,213.7 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                   | 1KB          |     2,631.8 ns |     23.77 ns |     22.23 ns |     2,630.3 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                    | **1KB**          |     **2,676.5 ns** |     **18.19 ns** |     **17.01 ns** |     **2,674.8 ns** |      **96 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-1 | OS Native**                      | **1025B**        |     **1,213.0 ns** |      **7.50 ns** |      **7.02 ns** |     **1,212.9 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                   | 1025B        |     2,621.6 ns |     17.57 ns |     16.43 ns |     2,617.9 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                    | **1025B**        |     **2,666.4 ns** |     **15.29 ns** |     **12.77 ns** |     **2,661.3 ns** |      **96 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-1 | OS Native**                      | **8KB**          |     **8,674.8 ns** |     **43.00 ns** |     **38.12 ns** |     **8,672.3 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                   | 8KB          |    19,499.9 ns |    141.42 ns |    132.28 ns |    19,479.7 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                    | **8KB**          |    **19,767.7 ns** |    **135.35 ns** |    **119.98 ns** |    **19,707.0 ns** |      **96 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-1 | OS Native**                      | **128KB**        |   **136,860.9 ns** |    **728.92 ns** |    **681.84 ns** |   **136,593.3 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                   | 128KB        |   309,320.7 ns |  1,742.76 ns |  1,544.91 ns |   308,707.1 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                    | **128KB**        |   **312,920.6 ns** |  **1,503.38 ns** |  **1,406.26 ns** |   **312,945.2 ns** |      **96 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-224 | BouncyCastle**                 | **128B**         |       **625.9 ns** |      **3.24 ns** |      **2.87 ns** |       **625.4 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                  | **128B**         |       **641.7 ns** |      **8.54 ns** |      **7.13 ns** |       **639.6 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-224 | BouncyCastle**                 | **137B**         |       **626.3 ns** |      **4.00 ns** |      **3.54 ns** |       **626.1 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                  | **137B**         |       **632.4 ns** |      **2.67 ns** |      **2.36 ns** |       **632.0 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA-224 | CryptoHives                  | 1KB          |     3,293.8 ns |     12.31 ns |     10.92 ns |     3,294.1 ns |     112 B |
| **ComputeHash | SHA-224 | BouncyCastle**                 | **1KB**          |     **3,326.4 ns** |     **12.77 ns** |     **11.32 ns** |     **3,327.8 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-224 | CryptoHives**                  | **1025B**        |     **3,302.3 ns** |     **13.46 ns** |     **11.94 ns** |     **3,300.1 ns** |     **112 B** |
| **ComputeHash | SHA-224 | BouncyCastle**                 | **1025B**        |     **3,314.8 ns** |     **10.79 ns** |     **10.09 ns** |     **3,316.7 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-224 | CryptoHives**                  | **8KB**          |    **24,512.0 ns** |    **117.02 ns** |    **109.46 ns** |    **24,496.0 ns** |     **112 B** |
| **ComputeHash | SHA-224 | BouncyCastle**                 | **8KB**          |    **24,851.4 ns** |    **147.31 ns** |    **137.80 ns** |    **24,836.8 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-224 | CryptoHives**                  | **128KB**        |   **385,955.4 ns** |    **934.94 ns** |    **780.72 ns** |   **385,863.1 ns** |     **112 B** |
| **ComputeHash | SHA-224 | BouncyCastle**                 | **128KB**        |   **392,048.1 ns** |  **1,118.76 ns** |    **991.75 ns** |   **391,750.5 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA-256 | OS Native                    | 128B         |       139.7 ns |      0.71 ns |      0.63 ns |       139.8 ns |     112 B |
| ComputeHash | SHA-256 | BouncyCastle                 | 128B         |       622.3 ns |      4.16 ns |      3.69 ns |       622.2 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                  | **128B**         |       **655.0 ns** |      **2.42 ns** |      **2.14 ns** |       **655.2 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-256 | OS Native**                    | **137B**         |       **145.3 ns** |      **2.36 ns** |      **2.20 ns** |       **144.9 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                 | 137B         |       616.7 ns |      2.45 ns |      2.18 ns |       616.5 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                  | **137B**         |       **652.5 ns** |      **2.44 ns** |      **2.04 ns** |       **652.9 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-256 | OS Native**                    | **1KB**          |       **508.6 ns** |      **2.17 ns** |      **2.03 ns** |       **508.0 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                 | 1KB          |     3,272.4 ns |     16.48 ns |     15.41 ns |     3,273.2 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                  | **1KB**          |     **3,401.1 ns** |     **16.74 ns** |     **14.84 ns** |     **3,400.2 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-256 | OS Native**                    | **1025B**        |       **511.4 ns** |      **2.45 ns** |      **2.29 ns** |       **511.6 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                 | 1025B        |     3,278.7 ns |     12.20 ns |     10.81 ns |     3,278.1 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                  | **1025B**        |     **3,433.1 ns** |     **12.24 ns** |     **10.85 ns** |     **3,431.9 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-256 | OS Native**                    | **8KB**          |     **3,328.8 ns** |      **5.36 ns** |      **4.48 ns** |     **3,327.8 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                 | 8KB          |    24,475.3 ns |     79.90 ns |     66.72 ns |    24,495.0 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                  | **8KB**          |    **25,224.2 ns** |     **80.47 ns** |     **67.19 ns** |    **25,207.0 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-256 | OS Native**                    | **128KB**        |    **51,847.0 ns** |     **61.01 ns** |     **50.94 ns** |    **51,838.1 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                 | 128KB        |   389,174.8 ns |  2,973.56 ns |  2,635.98 ns |   388,218.4 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                  | **128KB**        |   **399,315.2 ns** |    **709.82 ns** |    **592.74 ns** |   **399,281.7 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-384 | OS Native**                    | **128B**         |       **413.2 ns** |      **2.55 ns** |      **2.38 ns** |       **412.6 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                 | 128B         |       544.3 ns |      3.13 ns |      2.93 ns |       544.7 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                  | **128B**         |       **581.7 ns** |      **2.89 ns** |      **2.71 ns** |       **581.5 ns** |     **144 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-384 | OS Native**                    | **137B**         |       **411.2 ns** |      **1.79 ns** |      **1.67 ns** |       **410.8 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                 | 137B         |       550.3 ns |      2.21 ns |      2.07 ns |       549.6 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                  | **137B**         |       **578.9 ns** |      **1.77 ns** |      **1.57 ns** |       **578.6 ns** |     **144 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-384 | OS Native**                    | **1KB**          |     **1,524.3 ns** |     **12.73 ns** |     **11.28 ns** |     **1,521.4 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                 | 1KB          |     2,260.4 ns |      9.12 ns |      8.53 ns |     2,261.6 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                  | **1KB**          |     **2,289.4 ns** |      **8.17 ns** |      **7.64 ns** |     **2,290.2 ns** |     **144 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-384 | OS Native**                    | **1025B**        |     **1,520.2 ns** |      **4.24 ns** |      **3.76 ns** |     **1,520.1 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                 | 1025B        |     2,262.8 ns |      6.52 ns |      5.44 ns |     2,261.6 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                  | **1025B**        |     **2,290.9 ns** |      **8.94 ns** |      **8.36 ns** |     **2,292.1 ns** |     **144 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-384 | OS Native**                    | **8KB**          |    **10,505.4 ns** |     **40.33 ns** |     **33.68 ns** |    **10,504.8 ns** |     **144 B** |
| **ComputeHash | SHA-384 | CryptoHives**                  | **8KB**          |    **15,943.9 ns** |    **117.13 ns** |    **103.83 ns** |    **15,954.6 ns** |     **144 B** |
| **ComputeHash | SHA-384 | BouncyCastle**                 | **8KB**          |    **16,019.5 ns** |     **86.74 ns** |     **81.14 ns** |    **15,995.6 ns** |     **144 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA-384 | OS Native                    | 128KB        |   164,205.9 ns |  1,781.65 ns |  1,579.39 ns |   163,558.1 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                  | **128KB**        |   **250,169.6 ns** |  **1,236.20 ns** |  **1,095.85 ns** |   **250,586.9 ns** |     **144 B** |
| **ComputeHash | SHA-384 | BouncyCastle**                 | **128KB**        |   **251,335.9 ns** |  **1,358.98 ns** |  **1,061.00 ns** |   **251,229.5 ns** |     **144 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA-512 | OS Native                    | 128B         |       403.4 ns |      2.84 ns |      2.38 ns |       403.1 ns |     176 B |
| ComputeHash | SHA-512 | BouncyCastle                 | 128B         |       550.8 ns |      4.10 ns |      3.83 ns |       550.0 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                  | **128B**         |       **616.2 ns** |      **2.71 ns** |      **2.41 ns** |       **616.5 ns** |     **176 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512 | OS Native**                    | **137B**         |       **401.2 ns** |      **2.17 ns** |      **2.03 ns** |       **400.5 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                 | 137B         |       548.9 ns |      2.34 ns |      2.07 ns |       549.0 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                  | **137B**         |       **608.6 ns** |      **2.00 ns** |      **1.77 ns** |       **608.8 ns** |     **176 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512 | OS Native**                    | **1KB**          |     **1,522.8 ns** |      **7.39 ns** |      **6.91 ns** |     **1,523.9 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                 | 1KB          |     2,264.6 ns |      8.63 ns |      7.65 ns |     2,265.3 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                  | **1KB**          |     **2,403.5 ns** |      **7.68 ns** |      **6.00 ns** |     **2,402.5 ns** |     **176 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512 | OS Native**                    | **1025B**        |     **1,529.9 ns** |      **6.91 ns** |      **6.12 ns** |     **1,527.6 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                 | 1025B        |     2,267.8 ns |     10.83 ns |     10.13 ns |     2,266.3 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                  | **1025B**        |     **2,411.5 ns** |     **11.67 ns** |     **10.34 ns** |     **2,410.6 ns** |     **176 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512 | OS Native**                    | **8KB**          |    **10,455.4 ns** |     **44.99 ns** |     **37.57 ns** |    **10,466.0 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                 | 8KB          |    15,953.4 ns |     84.15 ns |     78.71 ns |    15,968.3 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                  | **8KB**          |    **16,756.3 ns** |     **69.58 ns** |     **65.08 ns** |    **16,765.5 ns** |     **176 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512 | OS Native**                    | **128KB**        |   **163,963.4 ns** |  **1,065.89 ns** |    **944.88 ns** |   **163,710.3 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                 | 128KB        |   250,922.2 ns |  1,282.49 ns |  1,136.90 ns |   251,008.5 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                  | **128KB**        |   **263,352.3 ns** |    **746.01 ns** |    **661.32 ns** |   **263,362.6 ns** |     **176 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**             | **128B**         |       **562.9 ns** |      **4.56 ns** |      **4.04 ns** |       **561.6 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**              | **128B**         |       **578.6 ns** |      **2.70 ns** |      **2.39 ns** |       **579.0 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**             | **137B**         |       **566.5 ns** |      **1.94 ns** |      **1.72 ns** |       **566.7 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**              | **137B**         |       **578.1 ns** |      **3.51 ns** |      **3.28 ns** |       **578.3 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**             | **1KB**          |     **2,277.8 ns** |     **11.15 ns** |      **8.70 ns** |     **2,280.4 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**              | **1KB**          |     **2,294.3 ns** |     **10.63 ns** |      **9.42 ns** |     **2,294.8 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA-512/224 | CryptoHives              | 1025B        |     2,296.8 ns |     13.36 ns |     11.84 ns |     2,296.4 ns |     112 B |
| **ComputeHash | SHA-512/224 | BouncyCastle**             | **1025B**        |     **2,298.6 ns** |     **11.44 ns** |     **10.70 ns** |     **2,302.5 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512/224 | CryptoHives**              | **8KB**          |    **15,960.3 ns** |     **93.87 ns** |     **83.21 ns** |    **15,990.0 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | BouncyCastle**             | **8KB**          |    **16,142.5 ns** |    **308.70 ns** |    **257.78 ns** |    **16,049.2 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512/224 | CryptoHives**              | **128KB**        |   **250,892.7 ns** |  **1,697.70 ns** |  **1,588.03 ns** |   **250,435.3 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | BouncyCastle**             | **128KB**        |   **251,041.2 ns** |    **852.21 ns** |    **755.46 ns** |   **251,251.4 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA-512/256 | BouncyCastle             | 128B         |       562.8 ns |      2.78 ns |      2.47 ns |       562.8 ns |     112 B |
| **ComputeHash | SHA-512/256 | CryptoHives**              | **128B**         |       **581.4 ns** |      **3.60 ns** |      **3.19 ns** |       **580.9 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512/256 | BouncyCastle**             | **137B**         |       **568.3 ns** |      **3.38 ns** |      **3.00 ns** |       **568.2 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | CryptoHives**              | **137B**         |       **579.5 ns** |      **2.33 ns** |      **2.07 ns** |       **579.1 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512/256 | BouncyCastle**             | **1KB**          |     **2,278.1 ns** |     **11.04 ns** |      **9.78 ns** |     **2,277.2 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | CryptoHives**              | **1KB**          |     **2,301.2 ns** |     **11.20 ns** |      **9.36 ns** |     **2,301.6 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512/256 | BouncyCastle**             | **1025B**        |     **2,285.2 ns** |      **9.39 ns** |      **7.84 ns** |     **2,286.8 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | CryptoHives**              | **1025B**        |     **2,297.1 ns** |     **11.25 ns** |      **9.98 ns** |     **2,296.5 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA-512/256 | CryptoHives              | 8KB          |    15,887.7 ns |     65.48 ns |     54.68 ns |    15,879.9 ns |     112 B |
| **ComputeHash | SHA-512/256 | BouncyCastle**             | **8KB**          |    **16,052.4 ns** |    **111.24 ns** |     **98.61 ns** |    **16,030.6 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHA-512/256 | CryptoHives**              | **128KB**        |   **250,642.6 ns** |  **1,815.62 ns** |  **1,609.50 ns** |   **250,350.5 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | BouncyCastle**             | **128KB**        |   **251,559.5 ns** |  **1,124.00 ns** |  **1,051.39 ns** |   **251,904.9 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar     | 128B         |       261.5 ns |      1.93 ns |      1.71 ns |       261.2 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F    | 128B         |       327.2 ns |      1.24 ns |      1.16 ns |       327.1 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                | 128B         |       391.1 ns |      0.88 ns |      0.82 ns |       391.0 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar     | 137B         |       257.1 ns |      1.79 ns |      1.50 ns |       256.7 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F    | 137B         |       326.3 ns |      0.72 ns |      0.56 ns |       326.5 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                | 137B         |       391.3 ns |      2.38 ns |      2.23 ns |       390.8 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar     | 1KB          |     1,799.5 ns |     11.32 ns |     10.59 ns |     1,797.1 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F    | 1KB          |     2,273.1 ns |      9.10 ns |      8.51 ns |     2,273.7 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                | 1KB          |     2,667.6 ns |      7.36 ns |      6.89 ns |     2,669.6 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar     | 1025B        |     1,806.6 ns |      8.97 ns |      7.01 ns |     1,809.4 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F    | 1025B        |     2,267.2 ns |      8.64 ns |      7.66 ns |     2,268.9 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                | 1025B        |     2,673.0 ns |     11.19 ns |      9.92 ns |     2,670.9 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar     | 8KB          |    12,312.6 ns |     80.55 ns |     75.35 ns |    12,299.0 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F    | 8KB          |    15,559.0 ns |     53.53 ns |     50.07 ns |    15,563.3 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                | 8KB          |    18,645.6 ns |     67.03 ns |     59.42 ns |    18,649.4 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar     | 128KB        |   195,477.0 ns |  1,225.67 ns |  1,146.49 ns |   194,942.2 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F    | 128KB        |   247,115.1 ns |    759.86 ns |    710.77 ns |   247,053.5 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                | 128KB        |   297,940.7 ns |  1,195.07 ns |    997.94 ns |   298,057.2 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar     | 128B         |       257.0 ns |      2.70 ns |      2.39 ns |       256.7 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F    | 128B         |       324.6 ns |      1.54 ns |      1.44 ns |       324.9 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                   | 128B         |       331.2 ns |      1.33 ns |      1.24 ns |       331.4 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                | 128B         |       393.2 ns |      1.73 ns |      1.53 ns |       392.6 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar     | 137B         |       532.8 ns |      5.71 ns |      5.34 ns |       531.4 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                   | 137B         |       573.8 ns |      2.68 ns |      2.38 ns |       573.5 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F    | 137B         |       641.7 ns |      1.31 ns |      1.22 ns |       641.5 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                | 137B         |       708.5 ns |      3.59 ns |      3.36 ns |       708.2 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar     | 1KB          |     1,775.3 ns |      7.88 ns |      7.37 ns |     1,775.0 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                   | 1KB          |     2,103.6 ns |     10.35 ns |      8.64 ns |     2,101.8 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F    | 1KB          |     2,254.8 ns |      5.64 ns |      5.27 ns |     2,255.2 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                | 1KB          |     2,672.9 ns |     17.25 ns |     15.29 ns |     2,671.4 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar     | 1025B        |     1,771.0 ns |      8.16 ns |      7.24 ns |     1,769.2 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                   | 1025B        |     2,089.4 ns |      8.07 ns |      6.30 ns |     2,090.1 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F    | 1025B        |     2,250.4 ns |      7.73 ns |      7.23 ns |     2,250.7 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                | 1025B        |     2,668.7 ns |     21.36 ns |     18.94 ns |     2,661.2 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar     | 8KB          |    13,048.7 ns |     40.11 ns |     33.49 ns |    13,040.9 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                   | 8KB          |    15,497.3 ns |     77.54 ns |     68.74 ns |    15,503.4 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F    | 8KB          |    16,721.8 ns |     52.44 ns |     49.06 ns |    16,724.0 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                | 8KB          |    20,035.9 ns |    150.09 ns |    133.05 ns |    20,013.7 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar     | 128KB        |   205,869.7 ns |  1,235.85 ns |  1,095.55 ns |   206,066.8 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                   | 128KB        |   243,709.1 ns |  1,196.03 ns |    998.74 ns |   243,385.0 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F    | 128KB        |   262,755.8 ns |    809.08 ns |    756.81 ns |   262,924.6 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                | 128KB        |   312,953.4 ns |  1,478.01 ns |  1,234.20 ns |   313,555.4 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar     | 128B         |       501.9 ns |      4.37 ns |      4.09 ns |       501.9 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                   | 128B         |       578.6 ns |      3.48 ns |      3.09 ns |       578.8 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F    | 128B         |       620.7 ns |      2.66 ns |      2.36 ns |       621.3 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                | 128B         |       714.3 ns |      3.34 ns |      2.79 ns |       713.6 ns |     144 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar     | 137B         |       497.2 ns |      3.76 ns |      3.33 ns |       496.6 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                   | 137B         |       573.8 ns |      2.63 ns |      2.46 ns |       574.1 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F    | 137B         |       616.0 ns |      2.65 ns |      2.35 ns |       616.5 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                | 137B         |       710.7 ns |      2.47 ns |      2.06 ns |       711.1 ns |     144 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar     | 1KB          |     2,171.2 ns |      8.63 ns |      7.65 ns |     2,169.6 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                   | 1KB          |     2,596.3 ns |     12.41 ns |     10.37 ns |     2,596.3 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F    | 1KB          |     2,808.3 ns |      4.47 ns |      3.74 ns |     2,808.2 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                | 1KB          |     3,320.2 ns |     20.04 ns |     18.74 ns |     3,319.3 ns |     144 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar     | 1025B        |     2,173.0 ns |     11.50 ns |     10.20 ns |     2,173.3 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                   | 1025B        |     2,598.3 ns |     14.93 ns |     13.23 ns |     2,593.7 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F    | 1025B        |     2,798.2 ns |      4.81 ns |      4.50 ns |     2,797.9 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                | 1025B        |     3,300.9 ns |      9.90 ns |      9.26 ns |     3,297.9 ns |     144 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar     | 8KB          |    16,801.7 ns |    129.94 ns |    115.18 ns |    16,743.6 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                   | 8KB          |    19,861.5 ns |     65.78 ns |     61.53 ns |    19,865.0 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F    | 8KB          |    21,953.2 ns |     23.47 ns |     21.95 ns |    21,957.0 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                | 8KB          |    25,873.7 ns |    118.89 ns |    105.39 ns |    25,863.7 ns |     144 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar     | 128KB        |   266,744.5 ns |  1,474.03 ns |  1,306.69 ns |   266,930.5 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                   | 128KB        |   316,214.0 ns |    738.19 ns |    616.43 ns |   316,424.0 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F    | 128KB        |   348,629.6 ns |    936.90 ns |    830.54 ns |   348,731.5 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                | 128KB        |   407,322.3 ns |  1,629.36 ns |  1,444.39 ns |   407,116.4 ns |     144 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar     | 128B         |       478.7 ns |      2.56 ns |      2.40 ns |       477.9 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                   | 128B         |       578.5 ns |      3.57 ns |      3.34 ns |       578.1 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F    | 128B         |       597.0 ns |      2.65 ns |      2.48 ns |       597.0 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                | 128B         |       701.3 ns |      2.50 ns |      2.34 ns |       701.1 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar     | 137B         |       473.9 ns |      2.91 ns |      2.72 ns |       474.3 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F    | 137B         |       598.8 ns |      2.25 ns |      2.00 ns |       599.0 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                   | 137B         |       600.8 ns |      5.41 ns |      4.80 ns |       600.7 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                | 137B         |       709.9 ns |      3.30 ns |      3.09 ns |       710.0 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar     | 1KB          |     3,219.9 ns |     21.50 ns |     19.06 ns |     3,215.1 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                   | 1KB          |     3,830.2 ns |     29.89 ns |     26.50 ns |     3,833.3 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F    | 1KB          |     4,125.2 ns |     11.43 ns |     10.69 ns |     4,124.7 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                | 1KB          |     4,867.4 ns |     26.35 ns |     22.00 ns |     4,872.5 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar     | 1025B        |     3,220.3 ns |     22.87 ns |     20.27 ns |     3,216.7 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                   | 1025B        |     3,812.9 ns |     17.51 ns |     15.52 ns |     3,813.4 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F    | 1025B        |     4,129.1 ns |     19.69 ns |     18.42 ns |     4,132.7 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                | 1025B        |     4,880.9 ns |     28.07 ns |     24.88 ns |     4,878.1 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar     | 8KB          |    24,033.2 ns |    126.19 ns |    118.04 ns |    24,013.3 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                   | 8KB          |    28,434.1 ns |     73.06 ns |     61.01 ns |    28,427.4 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F    | 8KB          |    30,887.3 ns |    121.69 ns |    113.83 ns |    30,879.2 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                | 8KB          |    36,777.4 ns |    149.67 ns |    132.68 ns |    36,793.1 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar     | 128KB        |   382,553.8 ns |  2,781.47 ns |  2,465.70 ns |   381,438.3 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                   | 128KB        |   453,422.8 ns |  2,327.32 ns |  2,176.98 ns |   453,627.5 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F    | 128KB        |   494,867.5 ns |  3,507.36 ns |  3,280.79 ns |   494,479.0 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                | 128KB        |   594,571.6 ns |  2,124.74 ns |  1,883.52 ns |   594,428.9 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHAKE128 | CryptoHives**                 | **128B**         |       **301.4 ns** |      **2.02 ns** |      **1.79 ns** |       **301.8 ns** |     **112 B** |
| **ComputeHash | SHAKE128 | BouncyCastle**                | **128B**         |       **390.3 ns** |      **1.70 ns** |      **1.51 ns** |       **389.9 ns** |     **112 B** |
| ComputeHash | SHAKE128 | OS Native                   | 128B         |       415.3 ns |      2.28 ns |      2.02 ns |       415.6 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHAKE128 | CryptoHives**                 | **137B**         |       **298.8 ns** |      **3.26 ns** |      **2.89 ns** |       **297.7 ns** |     **112 B** |
| **ComputeHash | SHAKE128 | BouncyCastle**                | **137B**         |       **391.4 ns** |      **2.89 ns** |      **2.56 ns** |       **390.7 ns** |     **112 B** |
| ComputeHash | SHAKE128 | OS Native                   | 137B         |       423.0 ns |      2.48 ns |      2.20 ns |       422.9 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHAKE128 | CryptoHives**                 | **1KB**          |     **1,629.8 ns** |      **9.25 ns** |      **8.20 ns** |     **1,628.4 ns** |     **112 B** |
| **ComputeHash | SHAKE128 | OS Native**                   | **1KB**          |     **1,942.7 ns** |     **17.19 ns** |     **15.24 ns** |     **1,938.8 ns** |     **112 B** |
| ComputeHash | SHAKE128 | BouncyCastle                | 1KB          |     2,364.8 ns |      6.72 ns |      5.61 ns |     2,365.9 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHAKE128 | CryptoHives**                 | **1025B**        |     **1,639.4 ns** |     **14.23 ns** |     **13.31 ns** |     **1,640.1 ns** |     **112 B** |
| **ComputeHash | SHAKE128 | OS Native**                   | **1025B**        |     **1,948.9 ns** |     **13.53 ns** |     **10.56 ns** |     **1,948.8 ns** |     **112 B** |
| ComputeHash | SHAKE128 | BouncyCastle                | 1025B        |     2,361.4 ns |     12.44 ns |     11.03 ns |     2,361.2 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHAKE128 | CryptoHives**                 | **8KB**          |    **10,657.6 ns** |     **92.87 ns** |     **86.87 ns** |    **10,642.7 ns** |     **112 B** |
| **ComputeHash | SHAKE128 | OS Native**                   | **8KB**          |    **12,693.3 ns** |     **87.96 ns** |     **77.97 ns** |    **12,666.8 ns** |     **112 B** |
| ComputeHash | SHAKE128 | BouncyCastle                | 8KB          |    16,179.0 ns |    101.48 ns |     94.92 ns |    16,170.2 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHAKE128 | CryptoHives**                 | **128KB**        |   **168,840.1 ns** |  **1,256.80 ns** |  **1,114.12 ns** |   **168,973.1 ns** |     **112 B** |
| **ComputeHash | SHAKE128 | OS Native**                   | **128KB**        |   **199,337.5 ns** |    **709.91 ns** |    **629.32 ns** |   **199,358.1 ns** |     **112 B** |
| ComputeHash | SHAKE128 | BouncyCastle                | 128KB        |   256,717.3 ns |  1,322.71 ns |  1,172.55 ns |   256,406.3 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHAKE256 | CryptoHives**                 | **128B**         |       **304.1 ns** |      **3.71 ns** |      **3.29 ns** |       **303.7 ns** |     **176 B** |
| **ComputeHash | SHAKE256 | BouncyCastle**                | **128B**         |       **388.6 ns** |      **2.06 ns** |      **1.93 ns** |       **388.1 ns** |     **176 B** |
| ComputeHash | SHAKE256 | OS Native                   | 128B         |       416.4 ns |      3.23 ns |      2.86 ns |       416.3 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHAKE256 | CryptoHives**                 | **137B**         |       **570.7 ns** |      **4.06 ns** |      **3.80 ns** |       **570.2 ns** |     **176 B** |
| **ComputeHash | SHAKE256 | OS Native**                   | **137B**         |       **667.6 ns** |      **3.14 ns** |      **2.94 ns** |       **667.4 ns** |     **176 B** |
| ComputeHash | SHAKE256 | BouncyCastle                | 137B         |       708.6 ns |      4.23 ns |      3.96 ns |       707.8 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHAKE256 | CryptoHives**                 | **1KB**          |     **1,807.5 ns** |     **10.46 ns** |      **9.27 ns** |     **1,805.5 ns** |     **176 B** |
| **ComputeHash | SHAKE256 | OS Native**                   | **1KB**          |     **2,186.0 ns** |      **8.49 ns** |      **7.09 ns** |     **2,185.4 ns** |     **176 B** |
| ComputeHash | SHAKE256 | BouncyCastle                | 1KB          |     2,670.4 ns |     12.13 ns |     10.75 ns |     2,668.7 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHAKE256 | CryptoHives**                 | **1025B**        |     **1,810.4 ns** |      **9.43 ns** |      **8.82 ns** |     **1,812.4 ns** |     **176 B** |
| **ComputeHash | SHAKE256 | OS Native**                   | **1025B**        |     **2,189.4 ns** |      **7.82 ns** |      **6.93 ns** |     **2,188.7 ns** |     **176 B** |
| ComputeHash | SHAKE256 | BouncyCastle                | 1025B        |     2,670.2 ns |      9.37 ns |      8.31 ns |     2,669.9 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHAKE256 | CryptoHives**                 | **8KB**          |    **13,071.8 ns** |     **88.32 ns** |     **78.29 ns** |    **13,031.4 ns** |     **176 B** |
| **ComputeHash | SHAKE256 | OS Native**                   | **8KB**          |    **15,586.6 ns** |    **102.53 ns** |     **95.90 ns** |    **15,558.0 ns** |     **176 B** |
| ComputeHash | SHAKE256 | BouncyCastle                | 8KB          |    19,963.1 ns |     95.36 ns |     84.53 ns |    19,953.9 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SHAKE256 | CryptoHives**                 | **128KB**        |   **205,062.8 ns** |  **1,135.37 ns** |  **1,062.03 ns** |   **204,668.1 ns** |     **176 B** |
| **ComputeHash | SHAKE256 | OS Native**                   | **128KB**        |   **243,020.9 ns** |  **1,160.65 ns** |  **1,028.89 ns** |   **242,780.7 ns** |     **176 B** |
| ComputeHash | SHAKE256 | BouncyCastle                | 128KB        |   316,094.3 ns |  1,331.64 ns |  1,180.46 ns |   316,128.9 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | SM3 | BouncyCastle                     | 128B         |       863.4 ns |      0.84 ns |      0.70 ns |       863.5 ns |     112 B |
| **ComputeHash | SM3 | CryptoHives**                      | **128B**         |     **1,026.8 ns** |      **4.74 ns** |      **4.20 ns** |     **1,027.0 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SM3 | BouncyCastle**                     | **137B**         |       **867.4 ns** |      **3.45 ns** |      **3.23 ns** |       **867.8 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                      | **137B**         |     **1,026.8 ns** |      **3.66 ns** |      **3.24 ns** |     **1,026.4 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SM3 | BouncyCastle**                     | **1KB**          |     **4,757.4 ns** |     **17.97 ns** |     **15.00 ns** |     **4,757.6 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                      | **1KB**          |     **5,573.8 ns** |     **11.95 ns** |      **9.98 ns** |     **5,571.9 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SM3 | BouncyCastle**                     | **1025B**        |     **4,771.6 ns** |     **28.36 ns** |     **26.53 ns** |     **4,763.3 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                      | **1025B**        |     **5,583.4 ns** |      **8.29 ns** |      **7.35 ns** |     **5,583.3 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SM3 | BouncyCastle**                     | **8KB**          |    **35,333.0 ns** |    **104.55 ns** |     **87.31 ns** |    **35,332.7 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                      | **8KB**          |    **41,977.3 ns** |     **91.98 ns** |     **81.54 ns** |    **41,998.3 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | SM3 | BouncyCastle**                     | **128KB**        |   **560,294.9 ns** |  **1,207.58 ns** |  **1,008.38 ns** |   **560,053.0 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                      | **128KB**        |   **668,770.0 ns** |  **2,892.13 ns** |  **2,563.79 ns** |   **667,847.1 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | Streebog-256 | CryptoHives             | 128B         |     2,654.4 ns |      8.22 ns |      7.29 ns |     2,652.7 ns |     112 B |
| **ComputeHash | Streebog-256 | OpenGost**                | **128B**         |     **3,692.0 ns** |     **27.15 ns** |     **24.07 ns** |     **3,691.6 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle            | 128B         |     4,617.9 ns |     40.34 ns |     37.73 ns |     4,614.7 ns |     200 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Streebog-256 | CryptoHives**             | **137B**         |     **3,473.3 ns** |     **69.36 ns** |     **68.12 ns** |     **3,480.6 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                | **137B**         |     **3,696.5 ns** |     **22.52 ns** |     **21.06 ns** |     **3,697.3 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle            | 137B         |     4,629.3 ns |     19.40 ns |     17.20 ns |     4,628.4 ns |     200 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Streebog-256 | CryptoHives**             | **1KB**          |    **10,533.1 ns** |     **15.32 ns** |     **13.58 ns** |    **10,533.6 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                | **1KB**          |    **13,715.9 ns** |     **98.68 ns** |     **92.31 ns** |    **13,684.2 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle            | 1KB          |    17,567.3 ns |     63.32 ns |     56.13 ns |    17,574.2 ns |     200 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Streebog-256 | CryptoHives**             | **1025B**        |    **10,374.6 ns** |     **44.63 ns** |     **41.75 ns** |    **10,375.9 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                | **1025B**        |    **16,164.0 ns** |    **297.86 ns** |    **278.62 ns** |    **16,197.1 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle            | 1025B        |    17,559.6 ns |     93.24 ns |     82.66 ns |    17,537.8 ns |     200 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Streebog-256 | CryptoHives**             | **8KB**          |    **69,136.0 ns** |    **210.57 ns** |    **175.83 ns** |    **69,143.0 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                | **8KB**          |    **93,319.0 ns** |    **292.75 ns** |    **273.84 ns** |    **93,229.5 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle            | 8KB          |   120,212.0 ns |    527.57 ns |    493.49 ns |   120,266.0 ns |     200 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Streebog-256 | CryptoHives**             | **128KB**        | **1,051,277.4 ns** |  **7,897.56 ns** |  **7,000.98 ns** | **1,051,481.9 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                | **128KB**        | **1,466,365.5 ns** | **16,046.76 ns** | **12,528.26 ns** | **1,463,796.1 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle            | 128KB        | 2,404,866.0 ns | 39,089.90 ns | 36,564.72 ns | 2,408,128.3 ns |     200 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**             | **128B**         |     **2,646.2 ns** |     **17.53 ns** |     **14.64 ns** |     **2,645.8 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                | **128B**         |     **3,618.5 ns** |     **55.19 ns** |     **46.09 ns** |     **3,609.9 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle            | 128B         |     4,607.6 ns |     33.92 ns |     31.72 ns |     4,607.1 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**             | **137B**         |     **2,769.1 ns** |      **6.79 ns** |      **6.02 ns** |     **2,769.4 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                | **137B**         |     **3,650.3 ns** |     **25.41 ns** |     **22.53 ns** |     **3,651.0 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle            | 137B         |     4,641.6 ns |     30.51 ns |     28.54 ns |     4,635.9 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**             | **1KB**          |     **9,991.1 ns** |     **17.79 ns** |     **15.77 ns** |     **9,992.3 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                | **1KB**          |    **16,596.1 ns** |    **304.29 ns** |    **269.74 ns** |    **16,613.0 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle            | 1KB          |    17,349.8 ns |     76.06 ns |     67.43 ns |    17,346.5 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**             | **1025B**        |     **9,858.2 ns** |     **31.26 ns** |     **26.10 ns** |     **9,859.6 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                | **1025B**        |    **13,516.5 ns** |     **48.70 ns** |     **45.55 ns** |    **13,492.2 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle            | 1025B        |    17,428.2 ns |     77.39 ns |     72.39 ns |    17,430.7 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**             | **8KB**          |    **70,022.1 ns** |    **249.96 ns** |    **233.81 ns** |    **69,984.2 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                | **8KB**          |    **93,316.7 ns** |    **398.43 ns** |    **332.71 ns** |    **93,243.8 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle            | 8KB          |   119,744.3 ns |    719.76 ns |    673.26 ns |   119,787.8 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**             | **128KB**        | **1,078,861.9 ns** |  **4,418.45 ns** |  **3,449.63 ns** | **1,079,597.1 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                | **128KB**        | **1,759,064.0 ns** | **28,258.22 ns** | **26,432.76 ns** | **1,761,694.5 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle            | 128KB        | 1,888,918.2 ns |  8,860.45 ns |  7,398.88 ns | 1,892,095.7 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | TurboSHAKE128 | CryptoHives**            | **128B**         |       **195.6 ns** |      **0.97 ns** |      **0.81 ns** |       **195.6 ns** |     **112 B** |
|                                                      |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE128 | CryptoHives            | 137B         |       195.6 ns |      1.15 ns |      1.02 ns |       195.1 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE128 | CryptoHives            | 1KB          |       932.8 ns |      4.28 ns |      3.80 ns |       932.7 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE128 | CryptoHives            | 1025B        |       936.8 ns |      4.65 ns |      3.88 ns |       937.3 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE128 | CryptoHives            | 8KB          |     5,752.0 ns |     19.42 ns |     16.21 ns |     5,745.8 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE128 | CryptoHives            | 128KB        |    90,551.0 ns |    175.72 ns |    155.77 ns |    90,568.2 ns |     112 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE256 | CryptoHives            | 128B         |       201.2 ns |      1.14 ns |      1.07 ns |       200.9 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE256 | CryptoHives            | 137B         |       363.8 ns |      1.26 ns |      1.05 ns |       363.9 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE256 | CryptoHives            | 1KB          |     1,017.6 ns |      4.92 ns |      4.36 ns |     1,018.2 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE256 | CryptoHives            | 1025B        |     1,020.0 ns |      6.85 ns |      5.72 ns |     1,019.4 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE256 | CryptoHives            | 8KB          |     7,073.8 ns |     27.21 ns |     24.12 ns |     7,074.8 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE256 | CryptoHives            | 128KB        |   109,403.0 ns |    241.37 ns |    188.45 ns |   109,400.8 ns |     176 B |
|                                                      |              |                |              |              |                |           |
| ComputeHash | Whirlpool | CryptoHives                | 128B         |     1,483.0 ns |     10.43 ns |      9.25 ns |     1,479.9 ns |     176 B |
| **ComputeHash | Whirlpool | BouncyCastle**               | **128B**         |     **5,453.2 ns** |     **39.10 ns** |     **36.58 ns** |     **5,443.1 ns** |     **232 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                | **137B**         |     **1,469.7 ns** |      **7.26 ns** |      **6.44 ns** |     **1,471.0 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**               | **137B**         |     **5,441.5 ns** |     **22.00 ns** |     **19.51 ns** |     **5,441.5 ns** |     **232 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                | **1KB**          |     **8,303.0 ns** |     **43.24 ns** |     **36.11 ns** |     **8,314.4 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**               | **1KB**          |    **33,231.8 ns** |    **196.21 ns** |    **183.54 ns** |    **33,189.9 ns** |     **232 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                | **1025B**        |     **8,324.3 ns** |     **59.27 ns** |     **52.54 ns** |     **8,329.1 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**               | **1025B**        |    **33,394.3 ns** |    **252.09 ns** |    **235.80 ns** |    **33,344.4 ns** |     **232 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                | **8KB**          |    **62,149.2 ns** |    **424.15 ns** |    **396.75 ns** |    **62,115.1 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**               | **8KB**          |   **255,846.7 ns** |  **1,840.13 ns** |  **1,631.23 ns** |   **256,000.1 ns** |     **232 B** |
|                                                      |              |                |              |              |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                | **128KB**        | **1,000,721.4 ns** |  **5,635.31 ns** |  **4,995.56 ns** | **1,000,810.8 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**               | **128KB**        | **4,081,778.5 ns** | **25,062.03 ns** | **20,927.93 ns** | **4,080,344.5 ns** |     **232 B** |
