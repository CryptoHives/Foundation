| Description                               | TestDataSize | Mean          | Error         | StdDev        | Median        | Allocated |
|------------------------------------------ |------------- |--------------:|--------------:|--------------:|--------------:|----------:|
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 17B          |     116.75 ns |      1.292 ns |      1.209 ns |     116.55 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 17B          |     116.93 ns |      1.701 ns |      1.591 ns |     116.70 ns |         - |
| Decrypt · AES-128-GCM (OS)                | 17B          |     119.18 ns |      2.236 ns |      1.982 ns |     118.45 ns |         - |
| Decrypt · AES-128-GCM (Managed)           | 17B          |     350.44 ns |      4.364 ns |      4.082 ns |     351.57 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 17B          |     588.80 ns |     11.745 ns |     15.679 ns |     591.99 ns |    1624 B |
|                                           |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 17B          |      64.35 ns |      0.459 ns |      0.384 ns |      64.39 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 17B          |      64.39 ns |      1.123 ns |      0.938 ns |      64.47 ns |         - |
| Encrypt · AES-128-GCM (OS)                | 17B          |     129.84 ns |      2.608 ns |      4.061 ns |     129.66 ns |         - |
| Encrypt · AES-128-GCM (Managed)           | 17B          |     334.09 ns |      6.691 ns |     10.613 ns |     331.55 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 17B          |     552.47 ns |     10.990 ns |     18.957 ns |     545.37 ns |    1608 B |
|                                           |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 65B          |     100.80 ns |      1.100 ns |      1.029 ns |     100.78 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 65B          |     103.26 ns |      1.546 ns |      1.447 ns |     103.70 ns |         - |
| Decrypt · AES-128-GCM (OS)                | 65B          |     123.24 ns |      2.471 ns |      2.644 ns |     122.81 ns |         - |
| Decrypt · AES-128-GCM (Managed)           | 65B          |     649.47 ns |     12.974 ns |     32.548 ns |     648.33 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 65B          |     863.91 ns |     36.479 ns |    107.560 ns |     803.29 ns |    1624 B |
|                                           |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 65B          |      71.61 ns |      1.450 ns |      1.285 ns |      71.08 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 65B          |      71.92 ns |      1.202 ns |      1.004 ns |      71.71 ns |         - |
| Encrypt · AES-128-GCM (OS)                | 65B          |     127.67 ns |      2.506 ns |      2.574 ns |     127.29 ns |         - |
| Encrypt · AES-128-GCM (Managed)           | 65B          |     593.93 ns |     11.882 ns |     13.206 ns |     592.51 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 65B          |     715.42 ns |      7.322 ns |      6.114 ns |     715.17 ns |    1608 B |
|                                           |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 128B         |      97.64 ns |      1.499 ns |      1.251 ns |      97.57 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 128B         |     100.13 ns |      1.523 ns |      1.424 ns |     100.11 ns |         - |
| Decrypt · AES-128-GCM (OS)                | 128B         |     122.35 ns |      2.156 ns |      2.016 ns |     122.69 ns |         - |
| Decrypt · AES-128-GCM (Managed)           | 128B         |     858.24 ns |      9.723 ns |      9.095 ns |     859.28 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 128B         |     923.48 ns |     10.538 ns |      9.342 ns |     923.67 ns |    1624 B |
|                                           |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 128B         |      59.33 ns |      0.734 ns |      0.651 ns |      59.16 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 128B         |      61.40 ns |      1.239 ns |      1.217 ns |      61.30 ns |         - |
| Encrypt · AES-128-GCM (OS)                | 128B         |     123.05 ns |      2.400 ns |      2.668 ns |     122.88 ns |         - |
| Encrypt · AES-128-GCM (Managed)           | 128B         |     858.34 ns |     16.410 ns |     16.852 ns |     854.86 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 128B         |     861.00 ns |     16.573 ns |     27.689 ns |     854.58 ns |    1608 B |
|                                           |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 152B         |     124.10 ns |      2.484 ns |      2.658 ns |     123.54 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 152B         |     126.73 ns |      2.560 ns |      2.739 ns |     127.11 ns |         - |
| Decrypt · AES-128-GCM (OS)                | 152B         |     136.42 ns |      2.587 ns |      2.657 ns |     136.02 ns |         - |
| Decrypt · AES-128-GCM (Managed)           | 152B         |   1,013.69 ns |     17.667 ns |     16.525 ns |   1,015.80 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 152B         |   1,041.87 ns |     19.480 ns |     18.221 ns |   1,044.64 ns |    1624 B |
|                                           |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 152B         |      84.79 ns |      1.053 ns |      0.985 ns |      85.14 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 152B         |      86.37 ns |      1.140 ns |      1.066 ns |      86.45 ns |         - |
| Encrypt · AES-128-GCM (OS)                | 152B         |     137.31 ns |      2.381 ns |      2.227 ns |     136.49 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 152B         |     973.99 ns |     11.121 ns |      9.858 ns |     972.14 ns |    1608 B |
| Encrypt · AES-128-GCM (Managed)           | 152B         |     995.59 ns |     18.295 ns |     17.114 ns |     999.74 ns |         - |
|                                           |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 256B         |     114.36 ns |      1.011 ns |      0.896 ns |     114.24 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 256B         |     121.45 ns |      2.364 ns |      2.529 ns |     120.56 ns |         - |
| Decrypt · AES-128-GCM (OS)                | 256B         |     128.87 ns |      2.546 ns |      2.381 ns |     128.76 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 256B         |   1,320.76 ns |     25.598 ns |     23.945 ns |   1,324.34 ns |    1624 B |
| Decrypt · AES-128-GCM (Managed)           | 256B         |   1,504.95 ns |     16.762 ns |     14.859 ns |   1,504.95 ns |         - |
|                                           |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 256B         |      75.60 ns |      1.477 ns |      1.517 ns |      75.21 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 256B         |      80.64 ns |      1.552 ns |      1.525 ns |      80.73 ns |         - |
| Encrypt · AES-128-GCM (OS)                | 256B         |     126.19 ns |      2.510 ns |      2.890 ns |     126.92 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 256B         |   1,288.19 ns |     25.368 ns |     34.724 ns |   1,283.88 ns |    1608 B |
| Encrypt · AES-128-GCM (Managed)           | 256B         |   1,512.01 ns |     22.291 ns |     20.851 ns |   1,511.30 ns |         - |
|                                           |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (OS)                | 1KB          |     179.80 ns |      2.553 ns |      2.263 ns |     180.36 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 1KB          |     204.99 ns |      2.356 ns |      1.967 ns |     205.16 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 1KB          |     245.61 ns |      2.470 ns |      2.190 ns |     245.00 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 1KB          |   3,757.49 ns |     41.653 ns |     38.962 ns |   3,749.77 ns |    1624 B |
| Decrypt · AES-128-GCM (Managed)           | 1KB          |   5,495.69 ns |     65.343 ns |     57.925 ns |   5,504.82 ns |         - |
|                                           |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 1KB          |     175.69 ns |      2.234 ns |      2.090 ns |     175.51 ns |         - |
| Encrypt · AES-128-GCM (OS)                | 1KB          |     184.32 ns |      1.924 ns |      1.706 ns |     184.23 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 1KB          |     206.04 ns |      2.076 ns |      1.734 ns |     206.05 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 1KB          |   3,676.10 ns |     20.497 ns |     18.170 ns |   3,676.37 ns |    1608 B |
| Encrypt · AES-128-GCM (Managed)           | 1KB          |   5,547.75 ns |     79.067 ns |     73.960 ns |   5,559.37 ns |         - |
|                                           |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (OS)                | 8KB          |     703.01 ns |     12.975 ns |     12.137 ns |     701.80 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 8KB          |   1,044.31 ns |     20.051 ns |     18.755 ns |   1,037.45 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 8KB          |   1,400.72 ns |     23.160 ns |     19.339 ns |   1,400.22 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 8KB          |  26,471.40 ns |    527.738 ns |    493.647 ns |  26,495.38 ns |    1624 B |
| Decrypt · AES-128-GCM (Managed)           | 8KB          |  42,834.46 ns |    756.249 ns |    707.396 ns |  42,844.90 ns |         - |
|                                           |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (OS)                | 8KB          |     667.86 ns |     11.939 ns |     11.168 ns |     666.28 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 8KB          |   1,129.54 ns |     21.912 ns |     26.910 ns |   1,127.34 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 8KB          |   1,340.82 ns |     25.325 ns |     23.689 ns |   1,342.48 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 8KB          |  26,440.16 ns |    307.479 ns |    287.616 ns |  26,435.86 ns |    1608 B |
| Encrypt · AES-128-GCM (Managed)           | 8KB          |  43,255.91 ns |    836.173 ns |    782.157 ns |  43,197.60 ns |         - |
|                                           |              |               |               |               |               |           |
| Decrypt · AES-128-GCM (OS)                | 128KB        |  10,982.63 ns |     40.742 ns |     36.117 ns |  10,997.31 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMulV256) | 128KB        |  15,854.79 ns |    194.708 ns |    182.130 ns |  15,862.22 ns |         - |
| Decrypt · AES-128-GCM (AES-NI+PClMul)     | 128KB        |  21,331.31 ns |    309.054 ns |    273.969 ns |  21,261.56 ns |         - |
| Decrypt · AES-128-GCM (BouncyCastle)      | 128KB        | 409,530.10 ns |  2,235.725 ns |  2,091.299 ns | 409,740.09 ns |    1624 B |
| Decrypt · AES-128-GCM (Managed)           | 128KB        | 665,401.61 ns |  2,180.325 ns |  1,820.670 ns | 665,262.65 ns |         - |
|                                           |              |               |               |               |               |           |
| Encrypt · AES-128-GCM (OS)                | 128KB        |   9,953.05 ns |    139.667 ns |    130.644 ns |   9,976.01 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMulV256) | 128KB        |  17,342.01 ns |    260.886 ns |    231.269 ns |  17,407.64 ns |         - |
| Encrypt · AES-128-GCM (AES-NI+PClMul)     | 128KB        |  20,730.65 ns |    209.323 ns |    185.559 ns |  20,760.75 ns |         - |
| Encrypt · AES-128-GCM (BouncyCastle)      | 128KB        | 415,197.78 ns |  5,577.924 ns |  4,657.820 ns | 416,195.34 ns |    1608 B |
| Encrypt · AES-128-GCM (Managed)           | 128KB        | 686,859.25 ns | 12,807.437 ns | 11,980.084 ns | 689,164.45 ns |         - |